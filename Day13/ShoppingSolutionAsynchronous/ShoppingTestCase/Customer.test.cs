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
        public async Task AddCustomerSuccssTest()
        {
            string customerName = "Ram";

            List<Customer> res = await _customerService.GetAllCustomers();
            Console.WriteLine(res.Count);
            int customerId = await _customerService.AddCustomer(customerName);

            Assert.AreEqual(1, customerId);
        }

        [Test]
        public async Task GetAllCustomerSuccess()
        {
            List<Customer> customers = await _customerService.GetAllCustomers();

            Assert.NotNull(customers);
        }

        [Test]
        public async Task GetCustomerSuccess()
        {
            string customerName = "Ram";
            int customerId = await _customerService.AddCustomer(customerName);

            Customer customer = await _customerService.GetCustomerById(customerId);

            Assert.NotNull(customer);
        }

        [Test]
        public async Task GetCustomerFail()
        {
            Assert.ThrowsAsync<IdNotFoundException>(async() =>
            {
                await _customerService.GetCustomerById(999);
            });
        }
        [Test]
        public async Task UpdateCustomerSuccessTest()
        {
            string customerName = "Ram";
            int customerId = await _customerService.AddCustomer(customerName);

            Customer customer = await _customerService.GetCustomerById(customerId);

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
        public async Task DeleteCustomerSuccessTest()
        {
            string customerName = "Ram";
            int customerId = await _customerService.AddCustomer(customerName);

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