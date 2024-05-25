using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Requests;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogItemService : BaseDataService<ApplicationDbContext>, ICatalogItemService
{
    private readonly ICatalogItemRepository _catalogItemRepository;
    private readonly IMapper _mapper;

    public CatalogItemService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogItemRepository catalogItemRepository,
        IMapper mapper)
        : base(dbContextWrapper, logger)
    {
        _catalogItemRepository = catalogItemRepository;
        _mapper = mapper;
    }

    public Task<int?> Add(string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName)
    {
        return ExecuteSafeAsync(() => _catalogItemRepository.Add(name, description, price, availableStock, catalogBrandId, catalogTypeId, pictureFileName));
    }

    public Task<CatalogItemDto> Get(int id)
    {
        var item = ExecuteSafeAsync(() => _catalogItemRepository.Get(id)).Result;

        return Task.Run(() => _mapper.Map<CatalogItemDto>(item));
    }

    public Task<List<CatalogItemDto>> GetByBrandName(string brandName)
    {
        var items = ExecuteSafeAsync(() => _catalogItemRepository.GetByBrandName(brandName)).Result;

        return Task.Run(() => _mapper.Map<List<CatalogItemDto>>(items));
    }

    public Task<List<CatalogItemDto>> GetByTypeName(string typeName)
    {
        var items = ExecuteSafeAsync(() => _catalogItemRepository.GetByTypeName(typeName)).Result;

        return Task.Run(() => _mapper.Map<List<CatalogItemDto>>(items));
    }

    public Task<CatalogItemDto> Update(UpdateProductRequest item)
    {
        var catalogItem = new CatalogItem()
        {
            Id = item.Id,
            Name = item.Name,
            Description = item.Description,
            Price = item.Price
        };
        catalogItem = ExecuteSafeAsync(() => _catalogItemRepository.Update(catalogItem)).Result;
        return Task.Run(() => _mapper.Map<CatalogItemDto>(catalogItem));
    }

    public Task<bool> Delete(int id)
    {
        return ExecuteSafeAsync(() => _catalogItemRepository.Delete(id));
    }
}