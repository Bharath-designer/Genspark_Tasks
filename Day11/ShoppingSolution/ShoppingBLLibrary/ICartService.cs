
using ShoppingModelLibrary;

namespace ShoppingBLLibrary
{
    public interface ICartService
    {
        void AddCartToCustomer(int id, Cart cart);
        void AddItemsToCart(int cartId, Product product);
        void UpdateCart(int cartId, Cart cart);
        Cart GetCartById(int cartId);
        List<Cart> GetAllCarts();
        void DeleteCart(int cartId);
    }
}
