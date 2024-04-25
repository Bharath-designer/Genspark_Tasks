

using ShoppingModelLibrary;

namespace ShoppingBLLibrary
{
    public interface ICustomerService
    {
        int AddCustomer(string customerName);
        void UpdateCustomer(int customerId, Customer customer);
        Customer GetCustomerById(int customerId);
        List<Customer> GetAllCustomers();
        void DeleteCustomer(int customerId);

    }
}
