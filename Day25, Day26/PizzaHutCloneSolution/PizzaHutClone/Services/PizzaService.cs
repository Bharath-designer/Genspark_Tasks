using PizzaHutClone.Exceptions;
using PizzaHutClone.Interfaces;
using PizzaHutClone.Models;
using PizzaHutClone.Models.DTOs;

namespace PizzaHutClone.Services
{
    public class PizzaService
    {
        private readonly IRepository<Pizza, int> _pizzaRepo;

        public PizzaService(IRepository<Pizza, int> pizzaRepo)
        {
            _pizzaRepo = pizzaRepo;
        }

        /// <exception cref="NoPizzaFoundException" />
        public async Task<Pizza> GetPizzaById(int id)
        {
            Pizza pizza = await _pizzaRepo.GetById(id);
            if (pizza == null) throw new NoPizzaFoundException();
            return pizza;
        }

        public async Task<IEnumerable<Pizza>> GetAllPizzas()
        {
            var pizzas = await _pizzaRepo.GetAll();
            return pizzas;
        }

        public async Task AddPizza(AddPizzaDTO pizzaDTO)
        {
            var pizza = new Pizza();
            pizza.Name = pizzaDTO.Name;
            pizza.PriceInRupees = pizzaDTO.PriceInRupees;
            pizza.InStock = pizzaDTO.InStock;
            await _pizzaRepo.Add(pizza);
        }

    }
}
