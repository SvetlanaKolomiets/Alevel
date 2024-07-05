using Homework23.Data.Entities;
using Homework23.Data;
using Microsoft.EntityFrameworkCore;
using Homework23.Repositories.Abstractions;

namespace Homework23.Repositories
{
	public class PetRepository : IPetRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PetRepository(ApplicationDbContext dbContext)
		{
            _dbContext = dbContext;
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

            var result = await _dbContext.Pets.AddAsync(new PetEntity()
            {
                Name = name,
                CategoryId = category,
                BreedId = breed,
                LocationId = location,
                Age = age,
                ImageUrl = imageUrl,
                Description = description
            });

            await _dbContext.SaveChangesAsync();

            return result.Entity.Id;
        }

        public async Task<PetEntity?> GetPetAsync(int id)
        {
            return await _dbContext.Pets.FirstOrDefaultAsync(p => p.Id == id);
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
            var pet = await _dbContext.Pets.FirstOrDefaultAsync(p => p.Id == id);

            if (pet == null)
            {
                throw new Exception($"Pet with Id {id} not found.");
            }

            pet.Name = name;
            pet.CategoryId = category;
            pet.BreedId = breed;
            pet.LocationId = location;
            pet.Age = age;
            pet.ImageUrl = imageUrl;
            pet.Description = description;

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletePetAsync(int id)
        {
            var pet = await _dbContext.Pets.FirstOrDefaultAsync(p => p.Id == id);

            if (pet == null)
            {
                throw new Exception($"Pet with Id {id} not found.");
            }

            _dbContext.Pets.Remove(pet);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<PetByCategory>> GetPetByCategory()
        {
            var results = await _dbContext.Pets
                .Where(p => p.Age > 3 && p.Location.LocationName == "Ukraine")
                .GroupBy(p => p.Category.CategoryName)
                .Select(p => new PetByCategory
                {
                    CategoryName = p.Key,
                    UniqueBreedCount = p.Select(p => p.BreedId).Distinct().Count()
                }).ToListAsync();

            return results;
        }
    }
}

