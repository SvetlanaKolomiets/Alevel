using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Requests;

namespace Catalog.UnitTests.Services;

public class CatalogBrandServiceTest
{
    private readonly ICatalogBrandService _catalogBrandService;

    private readonly Mock<ICatalogBrandRepository> _catalogBrandRepository;
    private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
    private readonly Mock<ILogger<CatalogBrandService>> _logger;
    private readonly Mock<IMapper> _mapper;

    private readonly CatalogBrand _testBrand = new CatalogBrand()
    {
        Brand = ".NET",
    };

    public CatalogBrandServiceTest()
    {
        _catalogBrandRepository = new Mock<ICatalogBrandRepository>();
        _dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();
        _logger = new Mock<ILogger<CatalogBrandService>>();
        _mapper = new Mock<IMapper>();

        var dbContextTransaction = new Mock<IDbContextTransaction>();
        _dbContextWrapper.Setup(s => s.BeginTransactionAsync(CancellationToken.None))
            .ReturnsAsync(dbContextTransaction.Object);

        _catalogBrandService = new CatalogBrandService(
            _dbContextWrapper.Object,
            _logger.Object,
            _catalogBrandRepository.Object,
            _mapper.Object);
    }

    [Fact]
    public async Task AddAsync_Success()
    {
        // arrange
        var brandId = 1;

        _catalogBrandRepository.Setup(s => s.Add(It.IsAny<string>()))
            .ReturnsAsync(brandId);

        // act
        var result = await _catalogBrandService.Add(_testBrand.Brand);

        // assert
        result.Should().Be(brandId);
    }

    [Fact]
    public async Task AddAsync_Failed()
    {
        // arrange
        int? brandId = null;

        _catalogBrandRepository.Setup(s => s.Add(It.IsAny<string>()))
            .ReturnsAsync(brandId);

        // act
        var result = await _catalogBrandService.Add(_testBrand.Brand);

        // assert
        result.Should().Be(brandId);
    }

    [Fact]
    public async Task GetAsync_Success()
    {
        // arrange
        var testBrands = new List<CatalogBrand>
        {
            _testBrand
        };

        var testBrandDtos = new List<CatalogBrandDto>
        {
            new CatalogBrandDto()
            {
                Id = 1,
                Brand = _testBrand.Brand,
            },
        };

        _catalogBrandRepository.Setup(s => s.GetBrandsAsync())
            .ReturnsAsync(testBrands);

        _mapper.Setup(m => m.Map<List<CatalogBrandDto>>(It.IsAny<List<CatalogBrand>>()))
            .Returns(testBrandDtos);

        // act
        var result = await _catalogBrandService.GetBrands();

        // assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(testBrandDtos);
    }

    [Fact]
    public async Task GetBrandsAsync_EmptyList()
    {
        // arrange
        var testBrands = new List<CatalogBrand>();

        var testBrandDtos = new List<CatalogBrandDto>();

        _catalogBrandRepository.Setup(s => s.GetBrandsAsync())
            .ReturnsAsync(testBrands);

        _mapper.Setup(m => m.Map<List<CatalogBrandDto>>(It.IsAny<List<CatalogBrand>>()))
            .Returns(testBrandDtos);

        // act
        var result = await _catalogBrandService.GetBrands();

        // assert
        result.Should().NotBeNull();
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task UpdateAsync_Success()
    {
        // arrange
        var updatedBrand = new CatalogBrand()
        {
            Id = 2,
            Brand = "test brand",
        };

        var updateRequest = new UpdateBrandRequest()
        {
            Id = 2,
            Brand = "test brand",
        };

        var catalogBrandDto = new CatalogBrandDto()
        {
            Id = 2,
            Brand = "test brand",
        };

        _catalogBrandRepository.Setup(i => i.Update(It.IsAny<CatalogBrand>()))
            .ReturnsAsync(updatedBrand);
        _mapper.Setup(m => m.Map<CatalogBrandDto>(It.IsAny<CatalogBrand>())).Returns(catalogBrandDto);

        // act
        var result = await _catalogBrandService.Update(updateRequest);

        // assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(catalogBrandDto);
    }

    [Fact]
    public async Task UpdateAsync_Failed()
    {
        // arrange
        var updateRequest = new UpdateBrandRequest()
        {
            Id = 2,
            Brand = "test brand",
        };

        _catalogBrandRepository.Setup(i => i.Update(It.IsAny<CatalogBrand>()))
            .ReturnsAsync((CatalogBrand)null);

        _mapper.Setup(m => m.Map<CatalogBrandDto>(It.IsAny<CatalogBrand>()))
            .Returns((CatalogBrandDto)null);

        // act
        var result = await _catalogBrandService.Update(updateRequest);

        // assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task DeleteAsync_Success()
    {
        // arrange
        var testId = 1;

        _catalogBrandRepository.Setup(i => i.Delete(It.Is<int>(id => id == testId)))
            .ReturnsAsync(true);

        // act
        var result = await _catalogBrandService.Delete(testId);

        // assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task DeleteAsync_Failed()
    {
        // arrange
        var testId = 1;

        _catalogBrandRepository.Setup(i => i.Delete(It.Is<int>(id => id == testId)))
            .ReturnsAsync(false);

        // act
        var result = await _catalogBrandService.Delete(testId);

        // assert
        result.Should().BeFalse();
    }
}