using Microsoft.Extensions.Logging;
using Homework23.Models;
using Homework23.Services.Abstractions;
using Homework23.Repositories.Abstractions;
using Homework23.Data;
using Homework23.Dto;

namespace Homework23.Services
{
	public class PetService : BaseDataService<ApplicationDbContext>, IPetService
    {
        private readonly IPetRepository _petRepository;
        private readonly ILogger<PetService> _loggerService;

        public PetService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            IPetRepository petRepository,
            ILogger<PetService> loggerService)
            : base(dbContextWrapper, logger)
        {
			_petRepository = petRepository;
			_loggerService = loggerService;
		}

		public async Task<int> AddPetAsync(
            string name,
            int category,
            int breed,
            int location,
            int age = default,
            string? imageUrl = default,
            string? description = default)
        {
            var id = await _petRepository.AddPetAsync(name, category, breed,
                location, age, imageUrl, description);

            _loggerService.LogInformation($"Created pet called {name} with {id}");
            return id;
        }

        public async Task<Pet> GetPetAsync(int id)
        {
            var result = await _petRepository.GetPetAsync(id);

            if (result == null)
            {
                _loggerService.LogWarning($"Not founded pet with Id = {id}");
                return null!;
            }

            return new Pet()
            {
                Name = result.Name,
                CategoryId = result.CategoryId,
                BreedId = result.BreedId,
                Age = result.Age,
                LocationId = result.LocationId,
                ImageUrl = result.ImageUrl,
                Description = result.Description

            };
        }

        public async Task UpdatePetAsync(
            int id,
            string name,
            int category,
            int breed,
            int location,
            int age = default,
            string? imageUrl = default,
            string? description = default)
        {
            await _petRepository.UpdatePetAsync(id, name, category, breed, location, age, imageUrl, description);
            _loggerService.LogInformation($"Updated pet with Id = {id}");
        }

        public async Task DeletePetAsync(int id)
        {
            await _petRepository.DeletePetAsync(id);
            _loggerService.LogInformation($"Deleted pet with Id = {id}");
        }

        public async Task<IEnumerable<PetByCategoryDto>> GetPetByCategoryDto()
        {
            var petsByCategory = await _petRepository.GetPetByCategory();

            foreach (var petByCategory in petsByCategory)
            {
                _loggerService.LogInformation($"Category: {petByCategory.CategoryName}, " +
                    $"Unique Breed Count: {petByCategory.UniqueBreedCount}");
            }

            return petsByCategory.Select(p => new PetByCategoryDto
            {
                CategoryName = p.CategoryName,
                UniqueBreedCount = p.UniqueBreedCount
            });
        }
    }
}

