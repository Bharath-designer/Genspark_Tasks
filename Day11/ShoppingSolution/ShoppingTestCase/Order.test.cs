using ShoppingBLLibrary;
using ShoppingDALLibrary;
using ShoppingModelLibrary;

namespace ShoppingTestCase
{
    public class OrderTest
    {
        IOrderService _orderService;
        ICustomerService _customerService;
        [SetUp]
        public void Setup()
        {
            IRepository<int, List<Order>> orderRepo = new Repository<int, List<Order>>();
            IRepository<int, Customer> customerRepo = new Repository<int, Customer>();
            IRepository<int, Cart> cartRepo = new Repository<int, Cart>();
            _orderService = new OrderBL(orderRepo);
            _customerService = new CustomerBL(customerRepo, cartRepo, orderRepo);
        }
        [Test]
        public void AddOrdersToCustomerSuccess()
        {
            _orderService.AddOrdersToCustomer(1, new List<Order>());    
        }

        [Test]
        public void AddOrdersToCustomerFail()
        {
            _orderService.AddOrdersToCustomer(1, new List<Order>());
            Assert.Throws<IdAlreadyFoundException>(() =>
            {
                _orderService.AddOrdersToCustomer(1, new List<Order>());
            });
        }

        [Test]
       public void CreateOrderSuccess()
        {
            int customerId = _customerService.AddCustomer("Ram");
            Customer customer = _customerService.GetCustomerById(customerId);

            Product product = new Product(1, "Laptop", Currency.Rupee, 50000);
            OrderedProduct orderedProduct = new OrderedProduct(product, 50000, 50000, 5);

            _orderService.CreateOrder(customer.OrdersId, new Order(1, orderedProduct, DateTime.Now, Currency.Rupee, 50000));

        }

        [Test]
        public void CreateOrderFail()
        {
            int customerId = _customerService.AddCustomer("Ram");
            Customer customer = _customerService.GetCustomerById(customerId);

            Product product = new Product(1, "Laptop", Currency.Rupee, 50000);
            OrderedProduct orderedProduct = new OrderedProduct(product, 50000, 50000, 6);

            Assert.Throws<QuantityExceededException>(() =>
            {
                _orderService.CreateOrder(customer.OrdersId, new Order(1, orderedProduct, DateTime.Now, Currency.Rupee, 50000));
            });
        }

            [Test]
            public void CreateOrderLimitBelow100TestFail()
            {
                int customerId = _customerService.AddCustomer("Ram");
                Customer customer = _customerService.GetCustomerById(customerId);

                Product product = new Product(1, "Pen", Currency.Rupee, 50);
                OrderedProduct orderedProduct = new OrderedProduct(product, 50, 50, 1);

                _orderService.CreateOrder(customer.OrdersId, new Order(1, orderedProduct, DateTime.Now, Currency.Rupee, orderedProduct.Price* orderedProduct.Quantity));

            }

        [Test]
        public void DeleteSuccesTest()
        {
            int customerId = _customerService.AddCustomer("Ram");
            Customer customer = _customerService.GetCustomerById(customerId);

            Product product = new Product(1, "Laptop", Currency.Rupee, 50000);
            OrderedProduct orderedProduct = new OrderedProduct(product, 50000, 50000, 1);

            _orderService.CreateOrder(customer.OrdersId, new Order(1, orderedProduct, DateTime.Now, Currency.Rupee, 50000));

            _orderService.DeleteOrder(customerId);
        }

        [Test] 
        public void GetAllSuccessTest()
        {
            List<List<Order>> orders = _orderService.GetAllOrders();

            Assert.NotNull(orders);
        }

        [Test]
         public void GetByIdSuccessTest()
        {
            int customerId = _customerService.AddCustomer("Ram");
            Customer customer = _customerService.GetCustomerById(customerId);

            Product product = new Product(1, "Laptop", Currency.Rupee, 50000);
            OrderedProduct orderedProduct = new OrderedProduct(product, 50000, 50000, 1);

            _orderService.CreateOrder(customer.OrdersId, new Order(1, orderedProduct, DateTime.Now, Currency.Rupee, 50000));

            List<Order> fetchedOrder = _orderService.GetOrderById(customer.OrdersId);

            Assert.AreEqual(1, fetchedOrder.Count);
        }

        [Test]
        public void GetByIdFailTest()
        {

            List<Order> orders = _orderService.GetOrderById(999);

            Assert.Null(orders);
        }

        [Test]
        public void UpdateSuccesTest()
        {
            int customerId = _customerService.AddCustomer("Ram");
            Customer customer = _customerService.GetCustomerById(customerId);

            Product product = new Product(1, "Laptop", Currency.Rupee, 50000);
            OrderedProduct orderedProduct = new OrderedProduct(product, 50000, 50000, 1);

            _orderService.CreateOrder(customer.OrdersId, new Order(1, orderedProduct, DateTime.Now, Currency.Rupee, 50000));

            List<Order> orders = new List<Order>();
            _orderService.UpdateOrder(customer.OrdersId, orders);
        }

    }
}