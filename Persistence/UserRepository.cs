using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Persistence.Context;
using GoingTo_API.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Persistence
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(User user)
        {
            await _context.users.AddAsync(user);
        }

        public async Task<User> FindById(int id)
        {
            return await _context.users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _context.users.ToListAsync();
        }

        public void Remove(User user)
        {
            _context.users.Remove(user);
        }

        public void Update(User user)
        {
            _context.users.Update(user);            
        }
    }
}
