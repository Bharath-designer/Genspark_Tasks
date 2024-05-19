using Microsoft.EntityFrameworkCore;
using PizzaHutClone.Context;
using PizzaHutClone.Exceptions;
using PizzaHutClone.Interfaces;
using PizzaHutClone.Models;

namespace PizzaHutClone.Repositories
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly PizzaHutCloneContext _context;

        public PizzaRepository(PizzaHutCloneContext _context)
        {
            this._context = _context;
        }

        public async Task<List<Pizza>> GetAll()
        {
            return await _context.Pizzas.ToListAsync();
        }

        /// <returns>Pizza or <c>null</c></returns>
        public async Task<Pizza?> GetById(int id)
        {
            Pizza? pizza = await _context.Pizzas.FindAsync(id);
            return pizza;
        }

        public async Task<List<Pizza>> GetAllBySellerId(int id)
        {
            List<Pizza> pizza = await _context.Pizzas.Where(p => p.SellerId == id).ToListAsync();
            return pizza;
        }

        public async Task<Pizza> Add(Pizza entity)
        {
            _context.Pizzas.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Pizza> Update(Pizza entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Pizza> Delete(Pizza pizza)
        {
            _context.Pizzas.Remove(pizza);
            await _context.SaveChangesAsync();
            return pizza;
        }
    }
}
