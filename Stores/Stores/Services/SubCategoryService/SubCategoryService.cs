using Microsoft.EntityFrameworkCore;
using Stores.Data;
using Stores.Entities;

namespace Stores.Services.SubCategoryService
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly DataContext _context;

        public SubCategoryService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<SubCategory>> GetSubCategories()
        {
            return await _context.SubCategories
                .Include(sc => sc.Category)               
                .ToListAsync();
        }

        public async Task<SubCategory?> GetSubCategoryById(int subCategoryId)
        {
            return await _context.SubCategories
                .Include(sc => sc.Category)
                .FirstOrDefaultAsync(sc => sc.SubCategoryID == subCategoryId);                
        }

        public async Task<SubCategory> CreateSubCategory(SubCategory subCategory)
        {
            _context.SubCategories.Add(subCategory);
            await _context.SaveChangesAsync();

            await _context.Entry(subCategory)
                .Reference(sc => sc.Category)
                .LoadAsync();

            return subCategory;
        }

        public async Task<SubCategory?> EditSubCategory(int subCategoryId, SubCategory subCategory)
        {
            var dbSubCategory = await _context.SubCategories.FindAsync(subCategoryId);

            if (dbSubCategory == null)
            {
                return null;
            }

            dbSubCategory.CategoryID = subCategory.CategoryID;
            dbSubCategory.SubCategoryTitle = subCategory.SubCategoryTitle;

            await _context.SaveChangesAsync();

            await _context.Entry(dbSubCategory)
                .Reference(sc => sc.Category)
                .LoadAsync();

            return dbSubCategory;
        }

        public async Task<bool> DeleteSubCategory(int subCategoryId)
        {
            var subCategory = await _context.SubCategories.FindAsync(subCategoryId);

            if (subCategory == null)
            {
                return false;
            }

            await _context.Entry(subCategory)
                .Reference(sc => sc.Category)
                .LoadAsync();

            _context.SubCategories.Remove(subCategory);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
