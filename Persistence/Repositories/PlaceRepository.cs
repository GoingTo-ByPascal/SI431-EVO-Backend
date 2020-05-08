using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Persistence.Context;
using GoingTo_API.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Persistence.Repositories
{
    public class PlaceRepository : BaseRepository, IPlaceRepository
    {
        public PlaceRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Place place)
        {
            await _context.Places.AddAsync(place);
        }

        public async Task<Place> FindById(int id)
        {
            return await _context.Places.FindAsync(id);
        }

        public async Task<IEnumerable<Place>> ListAsync()
        {
            return await _context.Places.Include(p=>p.Locatable).ToListAsync();
        }

        public void Remove(Place place)
        {
            _context.Places.Remove(place);
        }

        public void Update(Place place)
        {
            _context.Places.Update(place);
        }
    }
}
