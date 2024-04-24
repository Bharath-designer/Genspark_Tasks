using NUnit.Framework;
using ShoppingBLLibrary;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using System;

namespace ShoppingTestCase
{
    public class CartTests
    {
        ICartService _cartService;
        IRepository<int, Cart> _repository;

        [SetUp]
        public void Setup()
        {
            _repository = new Repository<int, Cart>();
            _cartService = new CartBL(_repository);
        }

        [Test]
        public void AddCartSuccessTest()
        {
            Cart cart = new Cart(1, new List<Product>(), 1);

            _cartService.AddCart(cart.Id, cart);

            Cart retrievedCart = _cartService.GetCartById(cart.Id);
            Assert.AreEqual(cart.Id, retrievedCart.Id);
        }

        [Test]
        public void AddCartFailTest()
        {
            Cart cart = new Cart(2, new List<Product>(), 1);

            _cartService.AddCart(cart.Id, cart);

            Assert.Throws<IdAlreadyFoundException>(() =>
            {
                _cartService.AddCart(cart.Id, cart);
            });
        }

        [Test]
        public void GetAllCartsSuccessTest()
        {
            Cart cart = new Cart(3, new List<Product>(), 1);
            _cartService.AddCart(cart.Id, cart);
            List<Cart> carts = _cartService.GetAllCarts();
            Assert.AreEqual(1, carts.Count);
            
        }

        [Test]
        public void GetCartByIdSuccessTest()
        {

            Cart cart = new Cart(4, new List<Product>(), 1);

            _cartService.AddCart(cart.Id, cart);

            Cart retrievedCart = _cartService.GetCartById(cart.Id);
            Assert.AreEqual(cart.Id, retrievedCart.Id);
        }

        [Test]
        public void GetCartByIdFailTest()
        {
            Assert.Throws<IdNotFoundException>(() =>
            {
                _cartService.GetCartById(999);
            });
        }

        [Test]
        public void UpdateCartSuccessTest()
        {
            Cart cart = new Cart(5, new List<Product>(), 1);
            _cartService.AddCart(cart.Id, cart);

            Cart updatedCart = new Cart(5, new List<Product>(), 2);
            _cartService.UpdateCart(cart.Id, updatedCart);

            Cart retrievedCart = _cartService.GetCartById(cart.Id);
            Assert.AreEqual(updatedCart.Id, retrievedCart.Id);
        }

        [Test]
        public void UpdateCartFailTest()
        {
            Cart cart = new Cart(999, new List<Product>(), 1);
            Assert.Throws<IdNotFoundException>(() =>
            {
                _cartService.UpdateCart(cart.Id, cart);
            });
        }

        [Test]
        public void DeleteCartSuccessTest()
        {

            Cart cart = new Cart(7, new List<Product>(), 1);
            _cartService.AddCart(cart.Id, cart);

            _cartService.DeleteCart(cart.Id);

            Assert.Throws<IdNotFoundException>(() =>
            {
                _cartService.GetCartById(cart.Id);
            });
        }

        [Test]
        public void DeleteCartFailTest()
        {
            Assert.Throws<IdNotFoundException>(() =>
            {
                _cartService.DeleteCart(999);
            });
        }
    }
}
