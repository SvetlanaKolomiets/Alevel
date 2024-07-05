using Homework23.Models;

namespace Homework23.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<int> AddCategoryAsync(string categoryName);
        Task<Category> GetCategoryAsync(int id);
        Task UpdateCategoryAsync(int id, string categoryName);
        Task DeleteCategoryAsync(int id);
    }
}

