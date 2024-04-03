using Homework23.Data;
using Homework23.Models;
using Homework23.Repositories.Abstractions;
using Homework23.Services.Abstractions;
using Microsoft.Extensions.Logging;

namespace Homework23.Services
{
	public class LocationService : BaseDataService<ApplicationDbContext>, ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly ILogger<LocationService> _loggerService;

        public LocationService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            ILocationRepository locationRepository,
            ILogger<LocationService> loggerService)
            : base(dbContextWrapper, logger)
        {
            _locationRepository = locationRepository;
            _loggerService = loggerService;
        }

        public async Task<int> AddLocationAsync(string locationName)
        {
            var id = await _locationRepository.AddLocationAsync(locationName);
            _loggerService.LogInformation($"Created location with Id = {id}");
            return id;
        }

        public async Task<Location> GetLocationAsync(int id)
        {
            var result = await _locationRepository.GetLocationAsync(id);

            if (result == null)
            {
                _loggerService.LogWarning($"Not found location with Id = {id}");
                return null!;
            }

            return new Location()
            {
                Id = result.Id,
                LocationName = result.LocationName
            };
        }

        public async Task UpdateLocationAsync(int id, string locationName)
        {
            await _locationRepository.UpdateLocationAsync(id, locationName);
            _loggerService.LogInformation($"Updated location with Id = {id}");
        }

        public async Task DeleteLocationAsync(int id)
        {
            await _locationRepository.DeleteLocationAsync(id);
            _loggerService.LogInformation($"Deleted location with Id = {id}");
        }
    }
}

