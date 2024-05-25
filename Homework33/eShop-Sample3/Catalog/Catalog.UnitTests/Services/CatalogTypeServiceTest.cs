using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Requests;

namespace Catalog.UnitTests.Services
{
    public class CatalogTypeServiceTest
    {
        private readonly ICatalogTypeService _catalogTypeService;
        private readonly Mock<ICatalogTypeRepository> _catalogTypeRepository;
        private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
        private readonly Mock<ILogger<CatalogTypeService>> _logger;
        private readonly Mock<IMapper> _mapper;

        private readonly CatalogType _testType = new CatalogType()
        {
            Type = "Mug",
        };

        public CatalogTypeServiceTest()
        {
            _catalogTypeRepository = new Mock<ICatalogTypeRepository>();
            _dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();
            _logger = new Mock<ILogger<CatalogTypeService>>();
            _mapper = new Mock<IMapper>();

            var dbContextTransaction = new Mock<IDbContextTransaction>();
            _dbContextWrapper.Setup(s => s.BeginTransactionAsync(CancellationToken.None))
                .ReturnsAsync(dbContextTransaction.Object);

            _catalogTypeService = new CatalogTypeService(
                _dbContextWrapper.Object,
                _logger.Object,
                _catalogTypeRepository.Object,
                _mapper.Object);
        }

        [Fact]
        public async Task AddAsync_Success()
        {
            // arrange
            var typeId = 1;

            _catalogTypeRepository.Setup(s => s.Add(It.IsAny<string>()))
                .ReturnsAsync(typeId);

            // act
            var result = await _catalogTypeService.Add(_testType.Type);

            // assert
            result.Should().Be(typeId);
        }

        [Fact]
        public async Task AddAsync_Failed()
        {
            // arrange
            int? typeId = null;

            _catalogTypeRepository.Setup(s => s.Add(It.IsAny<string>()))
                .ReturnsAsync(typeId);

            // act
            var result = await _catalogTypeService.Add(_testType.Type);

            // assert
            result.Should().Be(typeId);
        }

        [Fact]
        public async Task GetAsync_Success()
        {
            // arrange
            var testTypes = new List<CatalogType>
            {
                _testType
            };

            var testTypeDtos = new List<CatalogTypeDto>
            {
                new CatalogTypeDto()
                {
                    Id = 1,
                    Type = _testType.Type,
                },
            };

            _catalogTypeRepository.Setup(s => s.GetTypesAsync())
                .ReturnsAsync(testTypes);

            _mapper.Setup(m => m.Map<List<CatalogTypeDto>>(It.IsAny<List<CatalogType>>()))
                .Returns(testTypeDtos);

            // act
            var result = await _catalogTypeService.GetTypes();

            // assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(testTypeDtos);
        }

        [Fact]
        public async Task GetBrandsAsync_EmptyList()
        {
            // arrange
            var testTypes = new List<CatalogType>();

            var testTypeDtos = new List<CatalogTypeDto>();

            _catalogTypeRepository.Setup(s => s.GetTypesAsync())
                .ReturnsAsync(testTypes);

            _mapper.Setup(m => m.Map<List<CatalogTypeDto>>(It.IsAny<List<CatalogType>>()))
                .Returns(testTypeDtos);

            // act
            var result = await _catalogTypeService.GetTypes();

            // assert
            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }

        [Fact]
        public async Task UpdateAsync_Success()
        {
            // arrange
            var updatedType = new CatalogType()
            {
                Id = 2,
                Type = "test type",
            };

            var updateRequest = new UpdateTypeRequest()
            {
                Id = 2,
                Type = "test type",
            };

            var catalogTypeDto = new CatalogTypeDto()
            {
                Id = 2,
                Type = "test type",
            };

            _catalogTypeRepository.Setup(i => i.Update(It.IsAny<CatalogType>()))
                .ReturnsAsync(updatedType);
            _mapper.Setup(m => m.Map<CatalogTypeDto>(It.IsAny<CatalogType>())).Returns(catalogTypeDto);

            // act
            var result = await _catalogTypeService.Update(updateRequest);

            // assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(catalogTypeDto);
        }

        [Fact]
        public async Task UpdateAsync_Failed()
        {
            // arrange
            var updateRequest = new UpdateTypeRequest()
            {
                Id = 2,
                Type = "test type",
            };

            _catalogTypeRepository.Setup(i => i.Update(It.IsAny<CatalogType>()))
                .ReturnsAsync((CatalogType)null);

            _mapper.Setup(m => m.Map<CatalogTypeDto>(It.IsAny<CatalogType>()))
                .Returns((CatalogTypeDto)null);

            // act
            var result = await _catalogTypeService.Update(updateRequest);

            // assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task DeleteAsync_Success()
        {
            // arrange
            var testId = 1;

            _catalogTypeRepository.Setup(i => i.Delete(It.Is<int>(id => id == testId)))
                .ReturnsAsync(true);

            // act
            var result = await _catalogTypeService.Delete(testId);

            // assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task DeleteAsync_Failed()
        {
            // arrange
            var testId = 1;

            _catalogTypeRepository.Setup(i => i.Delete(It.Is<int>(id => id == testId)))
                .ReturnsAsync(false);

            // act
            var result = await _catalogTypeService.Delete(testId);

            // assert
            result.Should().BeFalse();
        }
    }
}
