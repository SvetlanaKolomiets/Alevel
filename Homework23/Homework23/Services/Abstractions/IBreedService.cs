using Homework23.Models;

namespace Homework23.Services.Abstractions
{
    public interface IBreedService
    {
        Task<int> AddBreedAsync(string breedName, int category);
        Task<Breed> GetBreedAsync(int id);
        Task UpdateBreedAsync(int id, string breedName, int category);
        Task DeleteBreedAsync(int id);
    }
}

