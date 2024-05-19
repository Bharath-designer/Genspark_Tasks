using PizzaHutClone.Exceptions;
using PizzaHutClone.Interfaces;
using PizzaHutClone.Models;
using PizzaHutClone.Models.DTOs;
using PizzaHutClone.Repositories;

namespace PizzaHutClone.Services
{
    public class PizzaService
    {
        private readonly IPizzaRepository _pizzaRepo;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PizzaService(IPizzaRepository pizzaRepo, IHttpContextAccessor httpContextAccessor)
        {
            _pizzaRepo = pizzaRepo;
            _httpContextAccessor = httpContextAccessor;
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
            int customerId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst("eid")?.Value);
            var pizza = new Pizza();
            pizza.Name = pizzaDTO.Name;
            pizza.PriceInRupees = pizzaDTO.PriceInRupees;
            pizza.InStock = pizzaDTO.InStock;
            pizza.SellerId = customerId;
            await _pizzaRepo.Add(pizza);
        }

        public async Task<List<PizzaReturnDTO>> GetAllPizzaForSeller()
        {
            int sellerId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst("eid")?.Value);
            List<Pizza> pizza = await _pizzaRepo.GetAllBySellerId(sellerId);
            List<PizzaReturnDTO> pizzaReturnDTO = pizza.Select(p =>
            {
                PizzaReturnDTO temp = new PizzaReturnDTO();
                temp.PizzaId = p.PizzaId;
                temp.Name = p.Name;
                temp.PriceInRupees = p.PriceInRupees;
                temp.InStock = p.InStock;
                return temp;
            }).ToList();
            return pizzaReturnDTO;
            
        }

    }
}
