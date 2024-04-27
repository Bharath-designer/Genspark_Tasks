

using ShoppingModelLibrary;

namespace ShoppingBLLibrary
{
    public interface ICustomerService
    {
        Task<int> AddCustomer(string customerName);
        void UpdateCustomer(int customerId, Customer customer);
        Task<Customer> GetCustomerById(int customerId);
        Task<List<Customer>> GetAllCustomers();
        void DeleteCustomer(int customerId);

    }
}
