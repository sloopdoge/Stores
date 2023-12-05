using Microsoft.EntityFrameworkCore;
using Stores.Data;
using Stores.Entities;

namespace Stores.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext _context;

        public CategoryService(DataContext context)
        {
            _context = context;
        }

        public async Task<Category> CreateCategory(Category category)
        {
            try
            {
                _context.Add(category);
                await _context.SaveChangesAsync();

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

            return dbCategory;    
        }

        public async Task<List<Category>> GetCategories()
        {
            await Task.Delay(1000);

            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetCategoryById(int categoryId)
        {
            var dbCategory = await _context.Categories.FindAsync(categoryId);

            return dbCategory;
        }
    }
}
