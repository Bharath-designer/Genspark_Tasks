using ShoppingDALLibrary;
using ShoppingModelLibrary;

namespace ShoppingBLLibrary
{
    public class CartBL : ICartService
    {
        IRepository<int, Cart> _repository;

        public CartBL(IRepository<int, Cart> repo)
        {
            _repository = repo;
        }
    
        public void AddCart(int id, Cart cart)
        {
            _repository.Add(id, cart);
        }

        public void DeleteCart(int cartId)
        {
            _repository.Delete(cartId);
        }

        public List<Cart> GetAllCarts()
        {
            return _repository.GetAll();
        }

        public Cart GetCartById(int cartId)
        {
            return _repository.GetById(cartId);
        }

        public void UpdateCart(int cartId, Cart cart)
        {
            _repository.Update(cartId, cart);
        }
    }

}
