using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Requests;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogTypeService
{
    Task<int?> Add(string type);
    Task<List<CatalogTypeDto>> GetTypes();
    Task<CatalogTypeDto> Update(UpdateTypeRequest type);
    Task<bool> Delete(int id);
}