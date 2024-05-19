using PizzaHutClone.Exceptions;
using PizzaHutClone.Interfaces;
using PizzaHutClone.Models;

namespace PizzaHutClone.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository _repo) {
            _repository = _repo;
        }

    }
}
