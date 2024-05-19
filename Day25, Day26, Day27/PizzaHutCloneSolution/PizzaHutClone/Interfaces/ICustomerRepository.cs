using PizzaHutClone.Models;

namespace PizzaHutClone.Interfaces
{
    public interface ICustomerRepository: IRepository<Customer, int>
    {
        public Task<Customer?> GetByEmailWithUser(string email);
        public Task<Customer?> GetByIdWithUser(int customerId);

    }
}
