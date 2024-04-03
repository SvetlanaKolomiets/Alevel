using Homework23.Models;
using Microsoft.Extensions.Logging;
using Homework23.Repositories.Abstractions;
using Homework23.Services.Abstractions;
using Homework23.Data;

namespace Homework23.Services
{
	public class BreedService : BaseDataService<ApplicationDbContext>, IBreedService
    {
        private readonly IBreedRepository _breedRepository;
        private readonly ILogger<BreedService> _loggerService;

        public BreedService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            IBreedRepository breedRepository,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            ILogger<BreedService> loggerService)
            : base(dbContextWrapper, logger)
        {
			_breedRepository = breedRepository;
			_loggerService = loggerService;
		}

        public async Task<int> AddBreedAsync(string breedName, int category)
        {
            var id = await _breedRepository.AddBreedAsync(breedName, category);

            _loggerService.LogInformation($"Created breed called {breedName} with Id {id}");
            return id;
        }

        public async Task<Breed> GetBreedAsync(int id)
        {
            var result = await _breedRepository.GetBreedAsync(id);

            if (result == null)
            {
                _loggerService.LogWarning($"Not founded breed with Id = {id}");
                return null!;
            }

            return new Breed()
            {
                Id = result.Id,
                BreedName = result.BreedName,
                CategoryId = result.CategoryId

            };
        }

        public async Task UpdateBreedAsync(int id, string breedName, int category)
        {
            await _breedRepository.UpdateBreedAsync(id, breedName, category);
            _loggerService.LogInformation($"Updated breed with Id {id}");
        }

        public async Task DeleteBreedAsync(int id)
        {
            await _breedRepository.DeleteBreedAsync(id);
            _loggerService.LogInformation($"Deleted breed with Id {id}");
        }
    }
}

