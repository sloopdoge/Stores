using Stores.Entities;

namespace Stores.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<List<Category>> GetCategories();
        Task<Category?> GetCategoryById(int categoryId);
        Task<Category> CreateCategory(Category category);
        Task<Category?> EditCategory(int categoryId, Category category);
        Task<bool> DeleteCategory(int categoryId);
    }
}
