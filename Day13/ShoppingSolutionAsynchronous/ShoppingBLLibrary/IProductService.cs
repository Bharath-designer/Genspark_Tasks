
using ShoppingModelLibrary;

namespace ShoppingBLLibrary
{
    public interface IProductService
    {
        void AddProduct(int id, Product product);
        void UpdateProduct(int productId, Product product);
        Task<Product> GetProductById(int productId);
        Task<List<Product>> GetAllProducts();
        void DeleteProduct(int productId);
    }
}
