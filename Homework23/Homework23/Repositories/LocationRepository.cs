using Homework23.Data;
using Homework23.Data.Entities;
using Homework23.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Homework23.Repositories
{
	public class LocationRepository : ILocationRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public LocationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddLocationAsync(string locationName)
        {
            var result = await _dbContext.Locations.AddAsync(new LocationEntity()
            {
                LocationName = locationName
            });


            await _dbContext.SaveChangesAsync();

            return result.Entity.Id;
        }

        public async Task<LocationEntity?> GetLocationAsync(int id)
        {
            return await _dbContext.Locations.FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task UpdateLocationAsync(int id, string locationName)
        {
            var location = await _dbContext.Locations.FirstOrDefaultAsync(l => l.Id == id);

            if (location == null)
            {
                throw new Exception($"Location with Id {id} not found.");
            }

            location.LocationName = locationName;

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteLocationAsync(int id)
        {
            var location = await _dbContext.Locations.FirstOrDefaultAsync(l => l.Id == id);

            if (location == null)
            {
                throw new Exception($"Location with Id {id} not found.");
            }

            _dbContext.Locations.Remove(location);
            await _dbContext.SaveChangesAsync();
        }
    }
}

