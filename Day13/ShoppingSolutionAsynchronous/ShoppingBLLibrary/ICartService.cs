
using ShoppingModelLibrary;

namespace ShoppingBLLibrary
{
    public interface ICartService
    {
        Task AddCartToCustomer(int id, Cart cart);
        Task AddItemsToCart(int cartId, Product product);
        void UpdateCart(int cartId, Cart cart);
        Task<Cart> GetCartById(int cartId);
        Task<List<Cart>> GetAllCarts();
        void DeleteCart(int cartId);
    }
}
