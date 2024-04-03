using Homework23.Models;

namespace Homework23.Services.Abstractions
{
	public interface ILocationService
	{
        Task<int> AddLocationAsync(string locationName);
        Task<Location> GetLocationAsync(int id);
        Task UpdateLocationAsync(int id, string locationName);
        Task DeleteLocationAsync(int id);
    }
}

