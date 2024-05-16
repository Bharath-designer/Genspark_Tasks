using Microsoft.EntityFrameworkCore;
using PizzaHutClone.Context;
using PizzaHutClone.Exceptions;
using PizzaHutClone.Interfaces;
using PizzaHutClone.Models;

namespace PizzaHutClone.Repositories
{
    public class CustomerRepository : IRepository<Customer, int>
    {
        private readonly PizzaHutCloneContext _context;

        public CustomerRepository(PizzaHutCloneContext _context)
        {
            this._context = _context;
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetById(int id)
        {
            Customer? customer = await _context.Customers.FindAsync(id);
            return customer;
        }
        
        public async Task<Customer?> GetByEmailWithUser(string email)
        {
            Customer? customer = await _context.Customers
                                   .Include(c => c.User)
                                   .FirstOrDefaultAsync(c => c.Email == email);

            return customer;
        }


        public async Task<Customer> Add(Customer entity)
        {
            _context.Customers.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Customer> Update(Customer entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Customer> Delete(Customer customer)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return customer;
        }
    }
}
