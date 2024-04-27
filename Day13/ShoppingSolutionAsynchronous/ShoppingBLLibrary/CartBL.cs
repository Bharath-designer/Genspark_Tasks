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

        public async Task AddCartToCustomer(int cartId, Cart cart)
        {
            
            if ((await _repository.GetById(cartId)) == null)
                _repository.Add(cartId, cart);
            else
                throw new IdAlreadyFoundException("Cart with the given ID already found");
        }

        public async Task AddItemsToCart(int cartId, Product product)
        {
            Cart cart = await _repository.GetById(cartId);
            if (cart != null)
                cart.Products.Add(product);
            else
                throw new IdNotFoundException("Id not found");
        }

        public void DeleteCart(int cartId)
        {
            _repository.Delete(cartId);
        }

        public async Task<List<Cart>> GetAllCarts()
        {
            return await _repository.GetAll();
        }

        public async Task<Cart> GetCartById(int cartId)
        {
            Cart cart =  await _repository.GetById(cartId);

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
