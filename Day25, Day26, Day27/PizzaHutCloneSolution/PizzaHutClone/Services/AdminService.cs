using PizzaHutClone.Exceptions;
using PizzaHutClone.Interfaces;
using PizzaHutClone.Models;
using PizzaHutClone.Repositories;

namespace PizzaHutClone.Services
{
    public class AdminService
    {
        private readonly IRepository<Customer, int> _repository;

        public AdminService(IRepository<Customer, int> _repo)
        {
            _repository = _repo;
        }


        /// <exception cref="NoCustomerFoundException"></exception>
        /// <exception cref="CustomerAlreadyActivatedException"></exception>
        public async Task ActivateCustomer(int customerId)
        {
            Customer? customer = await ((CustomerRepository)_repository).GetByIdWithUser(customerId);
            if (customer == null)
            {
                throw new NoCustomerFoundException();
            }

            if (customer.User.Status == "ACTIVE") throw new CustomerAlreadyActivatedException();

            customer.User.Status = "ACTIVE";
            await _repository.Update(customer);

        }
    }
}
