using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Stores.Data;
using Stores.Entities;

namespace Stores.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext _context;
        private readonly ILogger _logger;

        public CategoryService(DataContext context)
        {
            _context = context;

            _logger.LogInformation("Category Service: DataContext used");
        }

        public async Task<Category> CreateCategory(Category category)
        {
            try
            {
                _context.Add(category);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Category Service: Created category");

                return category;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"An error occurred while updating the database: {ex.Message}");

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");

                return null;
            }
            
        }

        public async Task<bool> DeleteCategory(int categoryId)
        {
            var dbCategory = await _context.Categories.FindAsync(categoryId);

            if (dbCategory == null)
                return false;

            _context.Remove(dbCategory);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Category Service: Deleted category");

            return true;
        }

        public async Task<Category?> EditCategory(int categoryId, Category category)
        {
            var dbCategory = await _context.Categories.FindAsync(categoryId);

            if (dbCategory != null)
            {
                dbCategory.CategoryTitle = category.CategoryTitle;

                await _context.SaveChangesAsync();
            }

            _logger.LogInformation("Category Service: Edited category");

            return dbCategory;    
        }

        public async Task<List<Category>> GetCategories()
        {
            await Task.Delay(1000);

            _logger.LogInformation("Category Service: Get all categories to List<Category>");

            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetCategoryById(int categoryId)
        {
            var dbCategory = await _context.Categories.FindAsync(categoryId);

            _logger.LogInformation("Category Service: Got category by ID");

            return dbCategory;
        }
    }
}
