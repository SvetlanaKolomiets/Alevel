using Homework23.Data.Entities;

namespace Homework23.Repositories.Abstractions
{
    public interface ILocationRepository
    {
        Task<int> AddLocationAsync(string locationName);
        Task<LocationEntity?> GetLocationAsync(int id);
        Task UpdateLocationAsync(int id, string locationName);
        Task DeleteLocationAsync(int id);
    }
}

