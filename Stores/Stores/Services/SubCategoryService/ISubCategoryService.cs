using Stores.Entities;

namespace Stores.Services.SubCategoryService
{
    public interface ISubCategoryService
    {
        Task<List<SubCategory>> GetSubCategories();
        Task<SubCategory?> GetSubCategoryById(int subCategoryId);
        Task<SubCategory> CreateSubCategory(SubCategory subCategory);
        Task<SubCategory?> EditSubCategory(int subCategoryId, SubCategory subCategory);
        Task<bool> DeleteSubCategory(int subCategoryId);
    }
}
