using Homework23.Dto;
using Homework23.Models;

namespace Homework23.Services.Abstractions
{
	public interface IPetService
	{
        Task<int> AddPetAsync(
            string name,
            int category,
            int breed,
            int location,
            int age = default,
            string? imageUrl = default,
            string? description = default);
        Task<Pet> GetPetAsync(int id);
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
        Task<IEnumerable<PetByCategoryDto>> GetPetByCategoryDto();
    }
}

