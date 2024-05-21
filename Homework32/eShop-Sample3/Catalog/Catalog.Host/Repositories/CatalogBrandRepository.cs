using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories;

public class CatalogBrandRepository : ICatalogBrandRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<CatalogBrandRepository> _logger;

    public CatalogBrandRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<CatalogBrandRepository> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }

    public async Task<int?> Add(string brand)
    {
        var item = await _dbContext.AddAsync(new CatalogBrand
        {
            Brand = brand
        });

        await _dbContext.SaveChangesAsync();

        return item.Entity.Id;
    }

    public async Task<List<CatalogBrand>> GetBrandsAsync()
    {
        return await _dbContext.CatalogBrands.ToListAsync();
    }

    public async Task<CatalogBrand> Update(CatalogBrand brand)
    {
        _dbContext.Attach(brand);
        _dbContext.Entry(brand).Property(x => x.Brand).IsModified = true;
        await _dbContext.SaveChangesAsync();
        return brand;
    }

    public async Task<bool> Delete(int id)
    {
        var brand = await _dbContext.CatalogBrands.FindAsync(id);
        if (brand == null)
        {
            _logger.LogWarning($"Brand with Id {id} not found.");
            return false;
        }

        _dbContext.CatalogBrands.Remove(brand);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}