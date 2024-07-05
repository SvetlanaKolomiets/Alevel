using Homework23.Data.Entities;
using Homework23.Data;
using Microsoft.EntityFrameworkCore;
using Homework23.Repositories.Abstractions;

namespace Homework23.Repositories
{
	public class СategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public СategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddCategoryAsync(string categoryName)
        {
            var result = await _dbContext.Categories.AddAsync(new CategoryEntity()
            {
                CategoryName = categoryName
            });


            await _dbContext.SaveChangesAsync();

            return result.Entity.Id;
        }

        public async Task<CategoryEntity?> GetCategoryAsync(int id)
        {
            return await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateCategoryAsync(int id, string categoryName)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                throw new Exception($"Category with Id {id} not found.");
            }

            category.CategoryName = categoryName;

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                throw new Exception($"Category with Id {id} not found.");
            }

            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();
        }
    }
}

