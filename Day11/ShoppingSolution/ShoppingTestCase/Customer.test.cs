using ShoppingBLLibrary;
using ShoppingDALLibrary;
using ShoppingModelLibrary;

namespace ShoppingTestCase
{
    public class CustomerTest
    {
        ICustomerService _customerService;
        [SetUp]
        public void Setup()
        {
            IRepository<int, Customer> customerRepo = new Repository<int, Customer>();
            IRepository<int, List<Order>> orderRepo = new Repository<int, List<Order>>();
            IRepository<int, Cart> cartRepo= new Repository<int, Cart>();
            _customerService = new CustomerBL(customerRepo, cartRepo, orderRepo);
        }

        [Test]
        public void AddCustomerSuccssTest()
        {
            string customerName = "Ram";

            int customerId = _customerService.AddCustomer(customerName);

            Assert.AreEqual(1, customerId);
        }

        [Test]
        public void GetAllCustomerSuccess()
        {
            List<Customer> customers = _customerService.GetAllCustomers();

            Assert.NotNull(customers);
        }

        [Test]
        public void GetCustomerSuccess()
        {
            string customerName = "Ram";
            int customerId = _customerService.AddCustomer(customerName);

            Customer customer = _customerService.GetCustomerById(customerId);

            Assert.NotNull(customer);
        }

        [Test]
        public void GetCustomerFail()
        {
            Assert.Throws<IdNotFoundException>(() =>
            {
                _customerService.GetCustomerById(999);
            });
        }
        [Test]
        public void UpdateCustomerSuccessTest()
        {
            string customerName = "Ram";
            int customerId = _customerService.AddCustomer(customerName);

            Customer customer = _customerService.GetCustomerById(customerId);

            _customerService.UpdateCustomer(customerId, customer);

            Assert.AreEqual(customerId, customer.Id);
        }

        [Test]
        public void UpdateCustomerFailTest()
        {
            
            Assert.Throws<IdNotFoundException>(() =>
            {
                _customerService.UpdateCustomer(999, null);

            });
        }

        [Test]
        public void DeleteCustomerSuccessTest()
        {
            string customerName = "Ram";
            int customerId = _customerService.AddCustomer(customerName);

            _customerService.DeleteCustomer(customerId);

        }

        [Test]
        public void DeleteCustomerFailTest()
        {
            Assert.Throws<IdNotFoundException>(() =>
            {
                _customerService.DeleteCustomer(999);
            });
        }
    }
}