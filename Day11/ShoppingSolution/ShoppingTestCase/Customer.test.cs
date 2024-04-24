using ShoppingBLLibrary;
using ShoppingDALLibrary;
using ShoppingModelLibrary;

namespace ShoppingTestCase
{
    public class Tests
    {
        ICustomerService _customerService;
        [SetUp]
        public void Setup()
        {
            IRepository<int, Customer> repo = new Repository<int, Customer>();
            _customerService = new CustomerBL(repo);
        }

        [Test]
        public void AddCustomerSuccssTest()
        {
            Cart cart = new Cart(1, new List<Product>(), 1);
            Customer customer = new Customer(1, "Ram", cart, new List<ShoppingModelLibrary.Order>());

            _customerService.AddCustomer(customer.Id, customer);
        }

        [Test]
        public void AddCustomerFailTest()
        {
            Cart cart = new Cart(1, new List<Product>(), 1);
            Customer customer = new Customer(2, "Ram", cart, new List<ShoppingModelLibrary.Order>());

            _customerService.AddCustomer(customer.Id, customer);

            Assert.Throws<IdAlreadyFoundException>(() =>
            {
                _customerService.AddCustomer(customer.Id, customer);
            });
        }

        [Test]
        public void GetAllCustomerSuccess()
        {
            _customerService.GetAllCustomers();
        }

        [Test]
        public void GetCustomerSuccess()
        {
            Cart cart = new Cart(1, new List<Product>(), 1);
            Customer customer = new Customer(3, "Ram", cart, new List<ShoppingModelLibrary.Order>());

            _customerService.AddCustomer(customer.Id, customer);

            _customerService.GetCustomerById(customer.Id);

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
            Cart cart = new Cart(1, new List<Product>(), 1);
            Customer customer = new Customer(4, "Ram", cart, new List<ShoppingModelLibrary.Order>());
            _customerService.AddCustomer(customer.Id, customer);

            Customer updatedCustomer = new Customer(4, "Ravi", cart, new List<ShoppingModelLibrary.Order>());
            _customerService.UpdateCustomer(customer.Id, updatedCustomer);

            Customer retrievedCustomer = _customerService.GetCustomerById(customer.Id);
            Assert.AreEqual(updatedCustomer.Id, retrievedCustomer.Id);
        }

        [Test]
        public void UpdateCustomerFailTest()
        {
            Cart cart = new Cart(1, new List<Product>(), 1);
            Customer customer = new Customer(999, "Ram", cart, new List<ShoppingModelLibrary.Order>());

            Assert.Throws<IdNotFoundException>(() =>
            {
                _customerService.UpdateCustomer(customer.Id, customer);

            });
        }

        [Test]
        public void DeleteCustomerSuccessTest()
        {
            Cart cart = new Cart(1, new List<Product>(), 1);
            Customer customer = new Customer(5, "Ram", cart, new List<ShoppingModelLibrary.Order>());
            _customerService.AddCustomer(customer.Id, customer);

            _customerService.DeleteCustomer(customer.Id);

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