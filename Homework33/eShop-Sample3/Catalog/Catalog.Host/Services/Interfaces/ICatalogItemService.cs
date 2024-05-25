using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Requests;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogItemService
{
    Task<int?> Add(string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName);
    Task<CatalogItemDto> Get(int id);
    Task<List<CatalogItemDto>> GetByBrandName(string brandName);
    Task<List<CatalogItemDto>> GetByTypeName(string typeName);
    Task<CatalogItemDto> Update(UpdateProductRequest request);
    Task<bool> Delete(int id);
}