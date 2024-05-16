using Microsoft.EntityFrameworkCore;
using PizzaHutClone.Context;
using PizzaHutClone.Exceptions;
using PizzaHutClone.Interfaces;
using PizzaHutClone.Models;

namespace PizzaHutClone.Repositories
{
    public class UserRepository : IRepository<User, int>
    {
        private readonly PizzaHutCloneContext _context;

        public UserRepository(PizzaHutCloneContext _context)
        {
            this._context = _context;
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }


        public async Task<User> GetById(int id)
        {
            User? user = await _context.Users.FindAsync(id);
            return user;
        }

        public async Task<User> Add(User entity)
        {
            _context.Users.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<User> Update(User entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;

        }


        public async Task<User> Delete(User user)
        {

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;

        }
    }
}
