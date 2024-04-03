using Homework23.Data.Entities;

namespace Homework23.Repositories.Abstractions
{
    public interface ICategoryRepository
    {
        Task<int> AddCategoryAsync(string categoryName);
        Task<CategoryEntity?> GetCategoryAsync(int id);
        Task UpdateCategoryAsync(int id, string categoryName);
        Task DeleteCategoryAsync(int id);
    }
}

