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
            OrderedProduct orderedProduct = new OrderedProduct(product, 50000, 50000, 1);

            _orderService.CreateOrder(customer.OrdersId, new Order(1, orderedProduct, DateTime.Now, Currency.Rupee, 50000));

        }

    }
}