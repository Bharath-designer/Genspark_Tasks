using PizzaHutClone.Interfaces;
using PizzaHutClone.Models;

namespace PizzaHutClone.Services
{
    public class CustomerService
    {
        private readonly IRepository<Customer, int> _repository;

        public CustomerService(IRepository<Customer,int> _repo) {
            _repository = _repo;
        }

    }
}
