
using ShoppingModelLibrary;

namespace ShoppingBLLibrary
{
    public interface IProductService
    {
        void AddProduct(int id, Product product);
        void UpdateProduct(int productId, Product product);
        Product GetProductById(int productId);
        List<Product> GetAllProducts();
        void DeleteProduct(int productId);
    }
}
