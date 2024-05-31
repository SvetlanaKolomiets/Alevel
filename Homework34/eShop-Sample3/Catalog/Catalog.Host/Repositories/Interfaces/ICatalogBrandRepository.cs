using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogBrandRepository
{
    Task<int?> Add(string brand);
    Task<List<CatalogBrand>> GetBrandsAsync();
    Task<CatalogBrand> Update(CatalogBrand brand);
    Task<bool> Delete(int id);
}