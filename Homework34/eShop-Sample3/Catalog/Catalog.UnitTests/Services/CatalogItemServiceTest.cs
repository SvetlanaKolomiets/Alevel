using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Requests;

namespace Catalog.UnitTests.Services;

public class CatalogItemServiceTest
{
    private readonly ICatalogItemService _catalogService;

    private readonly Mock<ICatalogItemRepository> _catalogItemRepository;
    private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
    private readonly Mock<ILogger<CatalogService>> _logger;
    private readonly Mock<IMapper> _mapper;

    private readonly CatalogItem _testItem = new CatalogItem()
    {
        Name = "Name",
        Description = "Description",
        Price = 1000,
        AvailableStock = 100,
        CatalogBrandId = 1,
        CatalogTypeId = 1,
        PictureFileName = "1.png",
    };

    public CatalogItemServiceTest()
    {
        _catalogItemRepository = new Mock<ICatalogItemRepository>();
        _dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();
        _logger = new Mock<ILogger<CatalogService>>();
        _mapper = new Mock<IMapper>();

        var dbContextTransaction = new Mock<IDbContextTransaction>();
        _dbContextWrapper.Setup(s => s.BeginTransactionAsync(CancellationToken.None))
            .ReturnsAsync(dbContextTransaction.Object);

        _catalogService = new CatalogItemService(
            _dbContextWrapper.Object,
            _logger.Object,
            _catalogItemRepository.Object,
            _mapper.Object);
    }

    [Fact]
    public async Task AddAsync_Success()
    {
        // arrange
        var testResult = 1;

        _catalogItemRepository.Setup(s => s.Add(
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<decimal>(),
            It.IsAny<int>(),
            It.IsAny<int>(),
            It.IsAny<int>(),
            It.IsAny<string>())).ReturnsAsync(testResult);

        // act
        var result = await _catalogService.Add(
            _testItem.Name,
            _testItem.Description,
            _testItem.Price,
            _testItem.AvailableStock,
            _testItem.CatalogBrandId,
            _testItem.CatalogTypeId,
            _testItem.PictureFileName);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task AddAsync_Failed()
    {
        // arrange
        int? testResult = null;

        _catalogItemRepository.Setup(s => s.Add(
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<decimal>(),
            It.IsAny<int>(),
            It.IsAny<int>(),
            It.IsAny<int>(),
            It.IsAny<string>())).ReturnsAsync(testResult);

        // act
        var result = await _catalogService.Add(
            _testItem.Name,
            _testItem.Description,
            _testItem.Price,
            _testItem.AvailableStock,
            _testItem.CatalogBrandId,
            _testItem.CatalogTypeId,
            _testItem.PictureFileName);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task GetAsync_Success()
    {
        // arrange
        var testId = 1;

        var testCatalogItemDto = new CatalogItemDto()
        {
            Id = testId,
            Name = _testItem.Name,
            Description = _testItem.Description,
            Price = _testItem.Price,
            AvailableStock = _testItem.AvailableStock,
            CatalogType = new CatalogTypeDto { Id = _testItem.CatalogTypeId, Type = "TestType" },
            CatalogBrand = new CatalogBrandDto { Id = _testItem.CatalogBrandId, Brand = "TestBrand" },
            PictureUrl = _testItem.PictureFileName,
        };

        _catalogItemRepository.Setup(s => s.Get(It.Is<int>(id => id == testId)))
            .ReturnsAsync(_testItem);
        _mapper.Setup(m => m.Map<CatalogItemDto>(It.IsAny<CatalogItem>())).Returns(testCatalogItemDto);

        // act
        var result = await _catalogService.Get(testId);

        // assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(testCatalogItemDto);
    }

    [Fact]
    public async Task GetAsync_Failed()
    {
        // arrange
        var testId = 1;

        _catalogItemRepository.Setup(s => s.Get(It.Is<int>(id => id == testId)))
            .ReturnsAsync((CatalogItem)null);

        // act
        var result = await _catalogService.Get(testId);

        // assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task GetByBrandAsync_Success()
    {
        // arrange
        var testBrand = "brand";
        var testCatalogItems = new List<CatalogItem>
        {
            _testItem
        };

        var testCatalogItemDtos = new List<CatalogItemDto>
        {
            new CatalogItemDto
            {
                Id = 1,
                Name = _testItem.Name,
                Description = _testItem.Description,
                Price = _testItem.Price,
                AvailableStock = _testItem.AvailableStock,
                CatalogType = new CatalogTypeDto { Id = _testItem.CatalogTypeId, Type = "TestType" },
                CatalogBrand = new CatalogBrandDto { Id = _testItem.CatalogBrandId, Brand = testBrand },
                PictureUrl = _testItem.PictureFileName,
            },
        };

        _catalogItemRepository.Setup(s => s.GetByBrandName(It.Is<string>(brandName => brandName == testBrand)))
            .ReturnsAsync(testCatalogItems);

        _mapper.Setup(m => m.Map<List<CatalogItemDto>>(It.IsAny<List<CatalogItem>>()))
            .Returns(testCatalogItemDtos);

        // act
        var result = await _catalogService.GetByBrandName(testBrand);

        // assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(testCatalogItemDtos);
    }

    [Fact]
    public async Task GetByBrandAsync_Failed()
    {
        // arrange
        var testBrand = "brand";
        var testCatalogItems = new List<CatalogItem>();

        var testCatalogItemDtos = new List<CatalogItemDto>();

        _catalogItemRepository.Setup(s => s.GetByBrandName(It.Is<string>(brandName => brandName == testBrand)))
            .ReturnsAsync(testCatalogItems);

        _mapper.Setup(m => m.Map<List<CatalogItemDto>>(It.IsAny<List<CatalogItem>>()))
            .Returns(testCatalogItemDtos);

        // act
        var result = await _catalogService.GetByBrandName(testBrand);

        // assert
        result.Should().NotBeNull();
        result.Should().BeEmpty();
        result.Should().BeEquivalentTo(testCatalogItemDtos);
    }

    [Fact]
    public async Task GetByTypeAsync_Success()
    {
        // arrange
        var testType = "type";
        var testCatalogItems = new List<CatalogItem>
        {
            _testItem
        };

        var testCatalogItemDtos = new List<CatalogItemDto>
        {
            new CatalogItemDto
            {
                Id = 1,
                Name = _testItem.Name,
                Description = _testItem.Description,
                Price = _testItem.Price,
                AvailableStock = _testItem.AvailableStock,
                CatalogType = new CatalogTypeDto { Id = _testItem.CatalogTypeId, Type = testType },
                CatalogBrand = new CatalogBrandDto { Id = _testItem.CatalogBrandId, Brand = "testBrand" },
                PictureUrl = _testItem.PictureFileName,
            },
        };

        _catalogItemRepository.Setup(s => s.GetByTypeName(It.Is<string>(typeName => typeName == testType)))
            .ReturnsAsync(testCatalogItems);

        _mapper.Setup(m => m.Map<List<CatalogItemDto>>(It.IsAny<List<CatalogItem>>()))
            .Returns(testCatalogItemDtos);

        // act
        var result = await _catalogService.GetByTypeName(testType);

        // assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(testCatalogItemDtos);
    }

    [Fact]
    public async Task GetByTypeAsync_Failed()
    {
        // arrange
        var testType = "type";
        var testCatalogItems = new List<CatalogItem>();

        var testCatalogItemDtos = new List<CatalogItemDto>();

        _catalogItemRepository.Setup(s => s.GetByTypeName(It.Is<string>(typeName => typeName == testType)))
            .ReturnsAsync(testCatalogItems);

        _mapper.Setup(m => m.Map<List<CatalogItemDto>>(It.IsAny<List<CatalogItem>>()))
            .Returns(testCatalogItemDtos);

        // act
        var result = await _catalogService.GetByTypeName(testType);

        // assert
        result.Should().NotBeNull();
        result.Should().BeEmpty();
        result.Should().BeEquivalentTo(testCatalogItemDtos);
    }

    [Fact]
    public async Task UpdateAsync_Success()
    {
        // arrange
        var updatedItem = new CatalogItem()
        {
            Id = 2,
            Name = "new item",
            Description = "new description",
            Price = 13,
        };

        var updateRequest = new UpdateProductRequest()
        {
            Id = 2,
            Name = "new item",
            Description = "new description",
            Price = 13,
        };

        var catalogItemDto = new CatalogItemDto()
        {
            Id = 2,
            Name = "new item",
            Description = "new description",
            Price = 13,
        };

        _catalogItemRepository.Setup(i => i.Update(It.IsAny<CatalogItem>()))
            .ReturnsAsync(updatedItem);
        _mapper.Setup(m => m.Map<CatalogItemDto>(It.IsAny<CatalogItem>())).Returns(catalogItemDto);

        // act
        var result = await _catalogService.Update(updateRequest);

        // assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(catalogItemDto);
    }

    [Fact]
    public async Task UpdateAsync_Failed()
    {
        // arrange
        var updateRequest = new UpdateProductRequest()
        {
            Id = 2,
            Name = "new item",
            Description = "new description",
            Price = 13,
        };

        _catalogItemRepository.Setup(i => i.Update(It.IsAny<CatalogItem>()))
            .ReturnsAsync((CatalogItem)null);
        _mapper.Setup(m => m.Map<CatalogItemDto>(It.IsAny<CatalogItem>())).Returns((CatalogItemDto)null);

        // act
        var result = await _catalogService.Update(updateRequest);

        // assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task DeleteAsync_Success()
    {
        // arrange
        var testId = 1;

        _catalogItemRepository.Setup(i => i.Delete(It.Is<int>(id => id == testId)))
            .ReturnsAsync(true);

        // act
        var result = await _catalogService.Delete(testId);

        // assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task DeleteAsync_Failed()
    {
        // arrange
        var testId = 1;

        _catalogItemRepository.Setup(i => i.Delete(It.Is<int>(id => id == testId)))
            .ReturnsAsync(false);

        // act
        var result = await _catalogService.Delete(testId);

        // assert
        result.Should().BeFalse();
    }

}