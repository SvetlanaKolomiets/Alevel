using Homework23.Data;
using Homework23.Data.Entities;
using Homework23.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Homework23.Repositories
{
	public class BreedRepository : IBreedRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BreedRepository(ApplicationDbContext dbContext)
		{
            _dbContext = dbContext;
        }

        public async Task<int> AddBreedAsync(string breedName, int category)
        {
            var result = await _dbContext.Breeds.AddAsync(new BreedEntity()
            {
                BreedName = breedName,
                CategoryId = category
            });


            await _dbContext.SaveChangesAsync();

            return result.Entity.Id;
        }

        public async Task<BreedEntity?> GetBreedAsync(int id)
        {
            return await _dbContext.Breeds.Include(i => i.Pet).FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task UpdateBreedAsync(int id, string breedName, int category)
        {
            var breed = await _dbContext.Breeds.Include(i => i.Pet).FirstOrDefaultAsync(b => b.Id == id);

            if (breed == null)
            {
                throw new Exception($"Breed with Id {id} does not exist.");
            }

            breed.BreedName = breedName;
            breed.CategoryId = category;

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteBreedAsync(int id)
        {
            var breed = await _dbContext.Breeds.Include(i => i.Pet).FirstOrDefaultAsync(b => b.Id == id);

            if (breed is null)
            {
                throw new Exception($"Breed with Id {id} does not exist.");
            }

            _dbContext.Breeds.Remove(breed);
            await _dbContext.SaveChangesAsync();
        }
    }
}

