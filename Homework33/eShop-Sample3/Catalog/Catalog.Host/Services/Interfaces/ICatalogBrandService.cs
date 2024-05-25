using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Requests;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogBrandService
{
    Task<int?> Add(string brand);
    Task<List<CatalogBrandDto>> GetBrands();
    Task<CatalogBrandDto> Update(UpdateBrandRequest brand);
    Task<bool> Delete(int id);
}