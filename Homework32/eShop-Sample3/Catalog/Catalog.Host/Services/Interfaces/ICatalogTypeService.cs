using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Requests;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogTypeService
{
    Task<int?> Add(string type);
    Task<List<CatalogBrandDto>> GetBrands();
    Task<CatalogTypeDto> Update(UpdateTypeRequest type);
    Task<bool> Delete(int id);
}