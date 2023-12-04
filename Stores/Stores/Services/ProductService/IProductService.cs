using Microsoft.AspNetCore.Mvc;
using Stores.Entities;

namespace Stores.Services.ProductService
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts();
        Task<Product?> GetProductById(int productId);
        Task<Product> CreateProduct(Product product);
        Task<Product?> EditProduct(int productId, Product product);
        Task<bool> DeleteProduct(int productId);
    }
}
