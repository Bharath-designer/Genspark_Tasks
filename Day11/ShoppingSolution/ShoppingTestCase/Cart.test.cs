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
        public void AddCartToCustomerFail()
        {
            Cart cart = new Cart(1, new List<Product>());

            _cartService.AddCartToCustomer(1, cart);

            Assert.Throws<IdAlreadyFoundException>(() =>
            {
                _cartService.AddCartToCustomer(1, cart);
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
        public void AddItemsToCartFail()
        {
            Cart cart = new Cart(1, new List<Product>());
            _cartService.AddCartToCustomer(1, cart);
            Product product = new Product(1, "Laptop", Currency.Rupee, 50000);

            Assert.Throws<IdNotFoundException>(() =>
            {
                _cartService.AddItemsToCart(999, product);
            });

        }

    }
}