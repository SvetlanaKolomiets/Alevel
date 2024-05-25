using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogTypeRepository
{
    Task<int?> Add(string type);
    Task<List<CatalogType>> GetTypesAsync();
    Task<CatalogType> Update(CatalogType type);
    Task<bool> Delete(int id);
}