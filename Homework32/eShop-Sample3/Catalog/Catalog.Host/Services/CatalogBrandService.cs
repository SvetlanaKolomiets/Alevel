using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Requests;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogBrandService : BaseDataService<ApplicationDbContext>, ICatalogBrandService
{
    private readonly ICatalogBrandRepository _catalogBrandRepository;
    private readonly IMapper _mapper;

    public CatalogBrandService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogBrandRepository catalogBrandRepository,
        IMapper mapper)
        : base(dbContextWrapper, logger)
    {
        _catalogBrandRepository = catalogBrandRepository;
        _mapper = mapper;
    }

    public Task<int?> Add(string brand)
    {
        return ExecuteSafeAsync(() => _catalogBrandRepository.Add(brand));
    }

    public Task<List<CatalogBrandDto>> GetBrands()
    {
        var brands = _catalogBrandRepository.GetBrandsAsync().Result;
        return Task.Run(() => _mapper.Map<List<CatalogBrandDto>>(brands));
    }

    public Task<CatalogBrandDto> Update(UpdateBrandRequest brand)
    {
        var catalogBrand = new CatalogBrand()
        {
            Id = brand.Id,
            Brand = brand.Brand
        };
        catalogBrand = ExecuteSafeAsync(() => _catalogBrandRepository.Update(catalogBrand)).Result;
        return Task.Run(() => _mapper.Map<CatalogBrandDto>(catalogBrand));
    }

    public Task<bool> Delete(int id)
    {
        return ExecuteSafeAsync(() => _catalogBrandRepository.Delete(id));
    }
}