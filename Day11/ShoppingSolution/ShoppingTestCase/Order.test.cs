using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingBLLibrary;
using ShoppingDALLibrary;
using ShoppingModelLibrary;

namespace ShoppingTestCase
{
    public class OrderTests
    {
        IOrderService _orderService;
        IRepository<int, Order> _repository;

        [SetUp]
        public void Setup()
        {
            _repository = new Repository<int, Order>();
            _orderService = new OrderBL(_repository);
        }

        [Test]
        public void AddOrderSuccessTest()
        {
            Order order = new Order(1, new List<Product>(), DateTime.Now, Currency.Rupee, 0);

            _orderService.AddOrder(order.Id, order);

            Order retrievedOrder = _orderService.GetOrderById(order.Id);
            Assert.AreEqual(order.Id, retrievedOrder.Id);
        }

        [Test]
        public void AddOrderSuccessTest2()
        {
            Product product1 = new Product(1, "Headphone",Currency.Rupee, 600);
            List<Product> products = new List<Product>();
            products.Add(product1);
            products.Add(product1);
            products.Add(product1);
            Order order = new Order(1, products, DateTime.Now, Currency.Rupee, 1800);

            _orderService.AddOrder(order.Id, order);

            Order retrievedOrder = _orderService.GetOrderById(order.Id);
            Assert.AreEqual(order.Id, retrievedOrder.Id);
        }

        [Test]
        public void AddOrderFailTest()
        {
            Order order = new Order(2, new List<Product>(), DateTime.Now, Currency.Rupee, 0);

            _orderService.AddOrder(order.Id, order);

            Assert.Throws<IdAlreadyFoundException>(() =>
            {
                _orderService.AddOrder(order.Id, order);
            });
        }

        [Test]
        public void GetAllOrdersSuccessTest()
        {
            Order order = new Order(3, new List<Product>(), DateTime.Now, Currency.Rupee, 0);

            _orderService.AddOrder(order.Id, order);

            List<Order> orders = _orderService.GetAllOrders();
            
        }

        [Test]
        public void GetOrderByIdSuccessTest()
        {
            Order order = new Order(4, new List<Product>(), DateTime.Now, Currency.Rupee, 0);

            _orderService.AddOrder(order.Id, order);

            Order retrievedOrder = _orderService.GetOrderById(order.Id);
        }

        [Test]
        public void GetOrderByIdFailTest()
        {
            Assert.Throws<IdNotFoundException>(() =>
            {
                _orderService.GetOrderById(999);
            });
        }

        [Test]
        public void UpdateOrderSuccessTest()
        {
            Order order = new Order(5, new List<Product>(), DateTime.Now, Currency.Rupee, 0);
            _orderService.AddOrder(order.Id, order);

            Order updatedOrder = new Order(5, new List<Product>(), DateTime.Now, Currency.Rupee, 0);
            _orderService.UpdateOrder(order.Id, updatedOrder);

            Order retrievedOrder = _orderService.GetOrderById(order.Id);
            Assert.AreEqual(updatedOrder.Id, retrievedOrder.Id);
        }

        [Test]
        public void UpdateOrderFailTest()
        {
            Order order = new Order(999, new List<Product>(), DateTime.Now, Currency.Rupee, 0);

            Assert.Throws<IdNotFoundException>(() =>
            {
                _orderService.UpdateOrder(order.Id, order);
            });
        }

        [Test]
        public void DeleteOrderSuccessTest()
        {
            Order order = new Order(6, new List<Product>(), DateTime.Now, Currency.Rupee, 0);
            _orderService.AddOrder(order.Id, order);

            _orderService.DeleteOrder(order.Id);

        }

        [Test]
        public void DeleteOrderFailTest()
        {
            
            Assert.Throws<IdNotFoundException>(() =>
            {
                _orderService.DeleteOrder(999);
            });
        }
    }

}
