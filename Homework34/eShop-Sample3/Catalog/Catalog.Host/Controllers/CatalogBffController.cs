using System.Net;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Enums;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;

[ApiController]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogBffController : ControllerBase
{
    private readonly ILogger<CatalogBffController> _logger;
    private readonly ICatalogService _catalogService;
    private readonly ICatalogItemService _catalogItemService;
    private readonly ICatalogBrandService _catalogBrandService;
    private readonly ICatalogTypeService _catalogTypeService;

    public CatalogBffController(
        ILogger<CatalogBffController> logger,
        ICatalogService catalogService,
        ICatalogItemService catalogItemService,
        ICatalogBrandService catalogBrandService,
        ICatalogTypeService catalogTypeService)
    {
        _logger = logger;
        _catalogService = catalogService;
        _catalogItemService = catalogItemService;
        _catalogBrandService = catalogBrandService;
        _catalogTypeService = catalogTypeService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogItemDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Items(PaginatedItemsRequest request)
    {
        var filters = new Dictionary<CatalogTypeFilter, int>();

        if (request.Filters?.Brand.HasValue ?? false)
        {
            filters.Add(CatalogTypeFilter.Brand, request.Filters.Brand.Value);
        }

        if (request.Filters?.Type.HasValue ?? false)
        {
            filters.Add(CatalogTypeFilter.Type, request.Filters.Type.Value);
        }

        var result = await _catalogService.GetCatalogItemsAsync(request.PageSize, request.PageIndex, filters);

        _logger.LogInformation("Received result: {@Result}", result);
        return Ok(result);
    }

    [HttpGet]
    [ProducesResponseType(typeof(CatalogItemDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetProductById(int id)
    {
        var result = await _catalogItemService.Get(id);
        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet]
    [ProducesResponseType(typeof(CatalogItemDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetByBrandName(string brandName)
    {
        var result = await _catalogItemService.GetByBrandName(brandName);
        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet]
    [ProducesResponseType(typeof(CatalogItemDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetByTypeName(string typeName)
    {
        var result = await _catalogItemService.GetByTypeName(typeName);
        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetBrands()
    {
        var brands = await _catalogBrandService.GetBrands();
        if (brands == null)
        {
            return NotFound();
        }

        return Ok(brands);
    }

    [HttpGet]
    public async Task<IActionResult> GetTypes()
    {
        var types = await _catalogTypeService.GetTypes();
        if (types == null)
        {
            return NotFound();
        }

        return Ok(types);
    }
}