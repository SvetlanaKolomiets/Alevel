using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories;

public class CatalogItemRepository : ICatalogItemRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<CatalogItemRepository> _logger;

    public CatalogItemRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<CatalogItemRepository> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }

    public async Task<PaginatedItems<CatalogItem>> GetByPageAsync(int pageIndex, int pageSize)
    {
        var totalItems = await _dbContext.CatalogItems
            .LongCountAsync();

        var itemsOnPage = await _dbContext.CatalogItems
            .Include(i => i.CatalogBrand)
            .Include(i => i.CatalogType)
            .OrderBy(c => c.Name)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedItems<CatalogItem>() { TotalCount = totalItems, Data = itemsOnPage };
    }

    public async Task<int?> Add(string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName)
    {
        var item = await _dbContext.AddAsync(new CatalogItem
        {
            CatalogBrandId = catalogBrandId,
            CatalogTypeId = catalogTypeId,
            Description = description,
            Name = name,
            PictureFileName = pictureFileName,
            Price = price
        });

        await _dbContext.SaveChangesAsync();

        return item.Entity.Id;
    }

    public async Task<CatalogItem?> Get(int id)
    {
        var item = await _dbContext.CatalogItems
            .Include(i => i.CatalogType)
            .Include(i => i.CatalogBrand)
            .FirstOrDefaultAsync(i => i.Id == id);
        if (item == null)
        {
            _logger.LogWarning($"Product with Id {id} not found.");
            return null;
        }

        return item;
    }

    public async Task<List<CatalogItem>?> GetByBrandName(string brandName)
    {
        var item = await _dbContext.CatalogItems
            .Include(i => i.CatalogType)
            .Include(i => i.CatalogBrand)
            .Where(i => i.CatalogBrand.Brand == brandName)
            .ToListAsync();
        if (item == null)
        {
            _logger.LogWarning($"Product with brand {brandName} not found.");
            return null;
        }

        return item;
    }

    public async Task<List<CatalogItem>?> GetByTypeName(string typeName)
    {
        var item = await _dbContext.CatalogItems
            .Include(i => i.CatalogType)
            .Include(i => i.CatalogBrand)
            .Where(i => i.CatalogType.Type == typeName)
            .ToListAsync();
        if (item == null)
        {
            _logger.LogWarning($"Product with type {typeName} not found.");
            return null;
        }

        return item;
    }

    public async Task<CatalogItem> Update(CatalogItem item)
    {
        _dbContext.Attach(item);
        _dbContext.Entry(item).Property(x => x.Name).IsModified = true;
        _dbContext.Entry(item).Property(x => x.Description).IsModified = true;
        _dbContext.Entry(item).Property(x => x.Price).IsModified = true;
        await _dbContext.SaveChangesAsync();
        return item;
    }

    public async Task<bool> Delete(int id)
    {
        var item = await _dbContext.CatalogItems.FindAsync(id);
        if (item == null)
        {
            _logger.LogWarning($"Product with Id {id} not found.");
            return false;
        }

        _dbContext.CatalogItems.Remove(item);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}