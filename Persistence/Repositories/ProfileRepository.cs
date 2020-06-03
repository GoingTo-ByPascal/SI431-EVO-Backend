using GoingTo_API.Domain.Models.Accounts;
using GoingTo_API.Domain.Persistence.Context;
using GoingTo_API.Domain.Repositories.Accounts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

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
            return await _context.Profiles
                .Include(p => p.Country)
                .ToListAsync();
        }

        public async Task<Profile> FindById(int id)
        {
            return await _context.Profiles
                .Where(p => p.Id == id)
                .Include(p=>p.Country)
                .FirstAsync();
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
