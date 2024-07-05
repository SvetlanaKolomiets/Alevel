using Homework23.Data.Entities;

namespace Homework23.Repositories.Abstractions
{
    public interface IBreedRepository
    {
        Task<int> AddBreedAsync(string breedName, int category);
        Task<BreedEntity?> GetBreedAsync(int id);
        Task UpdateBreedAsync(int id, string breedName, int category);
        Task DeleteBreedAsync(int id);
    }
}

