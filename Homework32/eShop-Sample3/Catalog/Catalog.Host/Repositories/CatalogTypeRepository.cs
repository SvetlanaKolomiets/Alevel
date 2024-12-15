using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories;

public class CatalogTypeRepository : ICatalogTypeRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<CatalogBrandRepository> _logger;

    public CatalogTypeRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<CatalogBrandRepository> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }

    public async Task<int?> Add(string type)
    {
        var item = await _dbContext.AddAsync(new CatalogType()
        {
            Type = type
        });

        await _dbContext.SaveChangesAsync();

        return item.Entity.Id;
    }

    public async Task<List<CatalogType>> GetTypesAsync()
    {
        return await _dbContext.CatalogTypes.ToListAsync();
    }

    public async Task<CatalogType> Update(CatalogType type)
    {
        _dbContext.Attach(type);
        _dbContext.Entry(type).Property(x => x.Type).IsModified = true;
        await _dbContext.SaveChangesAsync();
        return type;
    }

    public async Task<bool> Delete(int id)
    {
        var type = await _dbContext.CatalogTypes.FindAsync(id);
        if (type == null)
        {
            _logger.LogWarning($"Type with Id {id} not found.");
            return false;
        }

        _dbContext.CatalogTypes.Remove(type);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}