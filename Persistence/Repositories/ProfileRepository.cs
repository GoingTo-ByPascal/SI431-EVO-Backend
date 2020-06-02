using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Persistence.Context;
using GoingTo_API.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoingTo_API.Persistence.Repositories
{
    public class ProfileRepository : BaseRepository, IProfileRepository
    {
        public ProfileRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Profile profile)
        {
            await _context.Profiles.AddAsync(profile);
        }

        public async Task<IEnumerable<Profile>> ListAsync()
        {
            return await _context.Profiles.ToListAsync();
        }

        public async Task<Profile> FindById(int id)
        {
            return await _context.Profiles.FindAsync(id);
        }

        public void Update(Profile profile)
        {
            _context.Profiles.Update(profile);
        }

        public void Remove(Profile profile)
        {
            _context.Profiles.Remove(profile);
        }
    }
}
