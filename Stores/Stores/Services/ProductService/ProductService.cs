using Microsoft.EntityFrameworkCore;
using Stores.Data;
using Stores.Entities;

namespace Stores.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _context.Products
                .Include(p => p.Category)
                .Include(p => p.SubCategory)
                .ToListAsync();
        }

        public async Task<Product?> GetProductById(int productId)
        {
            return await _context.Products
                .Include(p => p.Category)
                .Include(p => p.SubCategory)
                .FirstOrDefaultAsync(p => p.ProductID == productId);
        }

        public async Task<Product> CreateProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product?> EditProduct(int productId, Product product)
        {
            var dbProduct = await _context.Products.FindAsync(productId);

            if (dbProduct == null)
            {
                return null;
            }

            dbProduct.CategoryID = product.CategoryID;
            dbProduct.SubCategoryID = product.SubCategoryID;
            dbProduct.ProductTitle = product.ProductTitle;
            dbProduct.TaxGroup = product.TaxGroup;
            dbProduct.IsMature = product.IsMature;
            dbProduct.ExciseNeeded = product.ExciseNeeded;

            await _context.SaveChangesAsync();
            return dbProduct;
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            var product = await _context.Products.FindAsync(productId);

            if (product == null)
            {
                return false;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
