
using ShoppingModelLibrary;

namespace ShoppingBLLibrary
{
    public interface ICartService
    {
        void AddCart(int id, Cart cart);
        void UpdateCart(int cartId, Cart cart);
        Cart GetCartById(int cartId);
        List<Cart> GetAllCarts();
        void DeleteCart(int cartId);
    }
}
