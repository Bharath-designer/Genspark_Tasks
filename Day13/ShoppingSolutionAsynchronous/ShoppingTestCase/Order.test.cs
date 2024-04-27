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
        public async Task AddOrdersToCustomerFail()
        {
            await _orderService.AddOrdersToCustomer(1, new List<Order>());
            Assert.ThrowsAsync<IdAlreadyFoundException>(async () =>
            {
                await _orderService.AddOrdersToCustomer(1, new List<Order>());
            });
        }

        [Test]
       public async Task CreateOrderSuccess()
        {
            int customerId = await _customerService.AddCustomer("Ram");
            Customer customer = await _customerService.GetCustomerById(customerId);

            Product product = new Product(1, "Laptop", Currency.Rupee, 50000);
            OrderedProduct orderedProduct = new OrderedProduct(product, 50000, 50000,5);

            _orderService.CreateOrder(customer.OrdersId, new Order(1, orderedProduct, DateTime.Now, Currency.Rupee, 50000));

        }

        [Test]
        public async Task CreateOrderFail()
        {
            int customerId = await _customerService.AddCustomer("Ram");
            Customer customer = await _customerService.GetCustomerById(customerId);

            Product product = new Product(1, "Laptop", Currency.Rupee, 50000);
            OrderedProduct orderedProduct = new OrderedProduct(product, 50000, 50000, 6);

            Assert.ThrowsAsync<QuantityExceededException>(async () =>
            {
                await _orderService.CreateOrder(customer.OrdersId, new Order(1, orderedProduct, DateTime.Now, Currency.Rupee, 50000));
            });
        }

            [Test]
            public async Task CreateOrderLimitBelow100TestFail()
            {
                int customerId = await _customerService.AddCustomer("Ram");
                Customer customer = await _customerService.GetCustomerById(customerId);

                Product product = new Product(1, "Pen", Currency.Rupee, 50);
                OrderedProduct orderedProduct = new OrderedProduct(product, 50, 50, 1);

                _orderService.CreateOrder(customer.OrdersId, new Order(1, orderedProduct, DateTime.Now, Currency.Rupee, orderedProduct.Price* orderedProduct.Quantity));

            }

        [Test]
        public async Task DeleteSuccesTest()
        {
            int customerId = await _customerService.AddCustomer("Ram");
            Customer customer = await _customerService.GetCustomerById(customerId);

            Product product = new Product(1, "Laptop", Currency.Rupee, 50000);
            OrderedProduct orderedProduct = new OrderedProduct(product, 50000, 50000, 1);

            _orderService.CreateOrder(customer.OrdersId, new Order(1, orderedProduct, DateTime.Now, Currency.Rupee, 50000));

            _orderService.DeleteOrder(customerId);
        }

        [Test] 
        public async Task GetAllSuccessTest()
        {
            List<List<Order>> orders = await _orderService.GetAllOrders();

            Assert.NotNull(orders);
        }

        [Test]
         public async Task GetByIdSuccessTest()
        {
            int customerId = await _customerService.AddCustomer("Ram");
            Customer customer = await _customerService.GetCustomerById(customerId);

            Product product = new Product(1, "Laptop", Currency.Rupee, 50000);
            OrderedProduct orderedProduct = new OrderedProduct(product, 50000, 50000, 1);

            _orderService.CreateOrder(customer.OrdersId, new Order(1, orderedProduct, DateTime.Now, Currency.Rupee, 50000));

            List<Order> fetchedOrder = await _orderService.GetOrderById(customer.OrdersId);

            Assert.AreEqual(1, fetchedOrder.Count);
        }

        [Test]
        public async Task GetByIdFailTest()
        {

            List<Order> orders = await _orderService.GetOrderById(999);

            Assert.Null(orders);
        }

        [Test]
        public async Task UpdateSuccesTest()
        {
            int customerId = await _customerService.AddCustomer("Ram");
            Customer customer = await _customerService.GetCustomerById(customerId);

            Product product = new Product(1, "Laptop", Currency.Rupee, 50000);
            OrderedProduct orderedProduct = new OrderedProduct(product, 50000, 50000, 1);

            _orderService.CreateOrder(customer.OrdersId, new Order(1, orderedProduct, DateTime.Now, Currency.Rupee, 50000));

            List<Order> orders = new List<Order>();
            _orderService.UpdateOrder(customer.OrdersId, orders);
        }

    }
}