using Homework23.Repositories.Abstractions;
using Homework23.Models;
using Homework23.Services.Abstractions;
using Microsoft.Extensions.Logging;
using Homework23.Data;

namespace Homework23.Services
{
    public class CategoryService : BaseDataService<ApplicationDbContext>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<CategoryService> _loggerService;

        public CategoryService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            ICategoryRepository categoryRepository,
            ILogger<CategoryService> loggerService)
            : base(dbContextWrapper, logger)
        {
            _categoryRepository = categoryRepository;
            _loggerService = loggerService;
        }

        public async Task<int> AddCategoryAsync(string categoryName)
        {
            var id = await _categoryRepository.AddCategoryAsync(categoryName);
            _loggerService.LogInformation($"Created category with Id = {id}");
            return id;
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            var result = await _categoryRepository.GetCategoryAsync(id);

            if (result == null)
            {
                _loggerService.LogWarning($"Not found category with Id = {id}");
                return null!;
            }

            return new Category()
            {
                Id = result.Id,
                CategoryName = result.CategoryName
            };
        }

        public async Task UpdateCategoryAsync(int id, string categoryName)
        {
            await _categoryRepository.UpdateCategoryAsync(id, categoryName);
            _loggerService.LogInformation($"Updated category with Id = {id}");
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await _categoryRepository.DeleteCategoryAsync(id);
            _loggerService.LogInformation($"Deleted category with Id = {id}");
        }
    }
}

