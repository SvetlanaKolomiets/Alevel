using Homework23.Data.Entities;

namespace Homework23.Repositories.Abstractions
{
    public interface IPetRepository
    {
        Task<int> AddPetAsync(
            string name,
            int category,
            int breed,
            int location,
            int age = default,
            string? imageUrl = default,
            string? description = default);

        Task<PetEntity?> GetPetAsync(int id);
        Task UpdatePetAsync(
            int id,
            string name,
            int category,
            int breed,
            int location,
            int age = default,
            string? imageUrl = default,
            string? description = default);
        Task DeletePetAsync(int id);
        Task<IEnumerable<PetByCategory>> GetPetByCategory();
    }
}

