using ShoppingBLLibrary;
using ShoppingDALLibrary;
using ShoppingModelLibrary;

namespace ShoppingTestCase
{
    public class CartTest
    {
        ICartService _cartService;
        [SetUp]
        public void Setup()
        {
            IRepository<int, Cart> cartRepo = new Repository<int, Cart>();
            _cartService = new CartBL(cartRepo);
        }

        [Test]
        public void AddCartToCustomerSuccess()
        {
            Cart cart = new Cart(1, new List<Product>());

            _cartService.AddCartToCustomer(1, cart);
        }
        [Test]
        public async Task AddCartToCustomerFail()
        {
            Cart cart = new Cart(1, new List<Product>());

            await _cartService.AddCartToCustomer(1, cart);

            Assert.ThrowsAsync<IdAlreadyFoundException>(async () =>
            {
                await _cartService.AddCartToCustomer(1, cart);
            });
        }
        [Test]
        public void AddItemsToCartSuccess()
        {
            Cart cart = new Cart(1, new List<Product>());
            _cartService.AddCartToCustomer(1, cart);
            Product product = new Product(1, "Laptop", Currency.Rupee, 50000);

            _cartService.AddItemsToCart(1, product);

        }

        [Test]
        public async Task AddItemsToCartFail()
        {
            Cart cart = new Cart(1, new List<Product>());
            await _cartService.AddCartToCustomer(1, cart);
            Product product = new Product(1, "Laptop", Currency.Rupee, 50000);

            Assert.ThrowsAsync<IdNotFoundException>(async () =>
            {
                await _cartService.AddItemsToCart(999, product);
            });

        }

        [Test]
        public void DeleteCart()
        {
            Cart cart = new Cart(1, new List<Product>());

            _cartService.AddCartToCustomer(1, cart);

            _cartService.DeleteCart(1);
        }

        [Test]
        public void DeleteCartFail()
        {
            Assert.Throws<IdNotFoundException>(() =>
            {
                _cartService.DeleteCart(999);
            });
        }

        [Test]
        public async Task GetAllSuccess()
        {
            List<Cart> carts = await _cartService.GetAllCarts();

            Assert.NotNull(carts);
        }

        [Test]
        public async Task GetByIdSuccess()
        {
            Cart cart = new Cart(1, new List<Product>());

            _cartService.AddCartToCustomer(1, cart);

            Cart fetchedCart = await _cartService.GetCartById(1);

            Assert.AreEqual(cart.Id, fetchedCart.Id);
        }

        [Test]
        public void GetByIdFail()
        {
            Assert.ThrowsAsync<IdNotFoundException>(async () =>
            {
                await _cartService.GetCartById(999);
            });
        }

        [Test]
        public void UpdateSuccess()
        {
            Cart cart = new Cart(1, new List<Product>());

            _cartService.AddCartToCustomer(1, cart);

            _cartService.UpdateCart(1, cart);
        }

        [Test]
        public void UpdateFail()
        {
            Cart cart = new Cart(1, new List<Product>());

            _cartService.AddCartToCustomer(1, cart);

            Assert.Throws<IdNotFoundException>(() =>
            {
                _cartService.UpdateCart(999, cart);
            });
        }

    }
}