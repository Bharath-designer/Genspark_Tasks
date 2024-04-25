

using ShoppingDALLibrary;
using ShoppingModelLibrary;

namespace ShoppingBLLibrary
{
    public class CustomerBL: ICustomerService
    {
        IRepository<int, Customer> _customerRepo;
        IRepository<int, Cart> _cartRepo;
        IRepository<int, List<Order>> _orderRepo;

        ICartService cartService;
        IOrderService orderService;
        public CustomerBL(IRepository<int, Customer> customerRepo, IRepository<int, Cart> cartRepo, IRepository<int, List<Order>> orderRepo)
        {
            _customerRepo = customerRepo;
            _cartRepo = cartRepo;
            _orderRepo = orderRepo;
            cartService = new CartBL(cartRepo);
            orderService = new OrderBL(_orderRepo);
        }

        public int AddCustomer(string customerName)
        {
            int customerId = _customerRepo .GetLatestId() + 1;
            int cartId = _cartRepo.GetLatestId() + 1;  
            int ordersId = _orderRepo.GetLatestId() + 1;

            cartService.AddCartToCustomer(cartId, new Cart(cartId, new List<Product>()));
            orderService.AddOrdersToCustomer(ordersId, new List<Order>());

            Customer customer = new Customer(customerId, customerName, cartId, ordersId);
            _customerRepo.Add(customerId, customer);

            return customerId;
        }

        public void DeleteCustomer(int customerId)
        {
            _customerRepo.Delete(customerId);
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerRepo.GetAll();
        }

        public Customer GetCustomerById(int customerId)
        {
            Customer customer = _customerRepo.GetById(customerId);
            if (customer == null)
            {
                throw new IdNotFoundException("Id not found");
            } else
            {
                return customer;

            }
        }

        public void UpdateCustomer(int customerId, Customer customer)
        {
            _customerRepo.Update(customerId, customer);
        }

    }
}
