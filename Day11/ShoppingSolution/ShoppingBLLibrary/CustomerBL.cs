

using ShoppingDALLibrary;
using ShoppingModelLibrary;

namespace ShoppingBLLibrary
{
    public class CustomerBL: ICustomerService
    {
        IRepository<int, Customer> _repository;

        public CustomerBL(IRepository<int, Customer> repository)
        {
            _repository = repository;
        }

        public void AddCustomer(int id, Customer customer)
        {
            _repository.Add(id, customer);
        }

        public void DeleteCustomer(int customerId)
        {
            _repository.Delete(customerId);
        }

        public List<Customer> GetAllCustomers()
        {
            return _repository.GetAll();
        }

        public Customer GetCustomerById(int customerId)
        {
            return _repository.GetById(customerId);
        }

        public void UpdateCustomer(int customerId, Customer customer)
        {
            _repository.Update(customerId, customer);
        }
    }
}
