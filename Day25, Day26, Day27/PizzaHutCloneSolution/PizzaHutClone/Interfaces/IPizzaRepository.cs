using PizzaHutClone.Models;

namespace PizzaHutClone.Interfaces
{
    public interface IPizzaRepository:IRepository<Pizza, int> 
    {
        public Task<List<Pizza>> GetAllBySellerId(int k);
    }
}
