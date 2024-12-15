using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Enums;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogItemRepository
{
    // Task<PaginatedItems<CatalogItem>> GetByPageAsync(int pageIndex, int pageSize);
    Task<PaginatedItems<CatalogItem>> GetByPageAsync(int pageIndex, int pageSize, Dictionary<CatalogTypeFilter, int> filters);
    Task<int?> Add(string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName);
    Task<CatalogItem?> Get(int id);
    Task<List<CatalogItem>?> GetByBrandName(string brandName);
    Task<List<CatalogItem>?> GetByTypeName(string typeName);
    Task<CatalogItem> Update(CatalogItem catalogItem);
    Task<bool> Delete(int id);
}