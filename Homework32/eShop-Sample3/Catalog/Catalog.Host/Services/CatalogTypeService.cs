using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Requests;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogTypeService : BaseDataService<ApplicationDbContext>, ICatalogTypeService
{
    private readonly ICatalogTypeRepository _catalogTypeRepository;
    private readonly IMapper _mapper;

    public CatalogTypeService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogTypeRepository catalogTypeRepository,
        IMapper mapper)
        : base(dbContextWrapper, logger)
    {
        _catalogTypeRepository = catalogTypeRepository;
        _mapper = mapper;
    }

    public Task<int?> Add(string type)
    {
        return ExecuteSafeAsync(() => _catalogTypeRepository.Add(type));
    }

    public Task<List<CatalogBrandDto>> GetBrands()
    {
        var types = _catalogTypeRepository.GetTypesAsync().Result;
        return Task.Run(() => _mapper.Map<List<CatalogBrandDto>>(types));
    }

    public Task<CatalogTypeDto> Update(UpdateTypeRequest type)
    {
        var catalogType = new CatalogType()
        {
            Id = type.Id,
            Type = type.Type
        };
        catalogType = ExecuteSafeAsync(() => _catalogTypeRepository.Update(catalogType)).Result;
        return Task.Run(() => _mapper.Map<CatalogTypeDto>(catalogType));
    }

    public Task<bool> Delete(int id)
    {
        return ExecuteSafeAsync(() => _catalogTypeRepository.Delete(id));
    }
}