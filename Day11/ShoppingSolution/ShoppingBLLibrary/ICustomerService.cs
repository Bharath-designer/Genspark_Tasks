

using ShoppingModelLibrary;

namespace ShoppingBLLibrary
{
    public interface ICustomerService
    {
        void AddCustomer(int id, Customer customer);
        void UpdateCustomer(int customerId, Customer customer);
        Customer GetCustomerById(int customerId);
        List<Customer> GetAllCustomers();
        void DeleteCustomer(int customerId);

    }
}
