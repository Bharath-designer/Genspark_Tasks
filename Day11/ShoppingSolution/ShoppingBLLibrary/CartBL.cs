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

        public void AddCartToCustomer(int cartId, Cart cart)
        {
            if (_repository.GetById(cartId) == null)
                _repository.Add(cartId, cart);
            else
                throw new IdAlreadyFoundException("Cart with the given ID already found");
        }

        public void AddItemsToCart(int cartId, Product product)
        {
            Cart cart = _repository.GetById(cartId);
            if (cart != null)
                cart.Products.Add(product);
            else
                throw new IdNotFoundException("Id not found");
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
            Cart cart = _repository.GetById(cartId);

            if (cart == null)
                throw new IdNotFoundException("Id not found");
            else return cart;
        }

        public void UpdateCart(int cartId, Cart cart)
        {
            _repository.Update(cartId, cart);
        }
    }

}
