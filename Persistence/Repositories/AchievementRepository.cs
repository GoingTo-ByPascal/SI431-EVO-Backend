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
    public class AchievementRepository : BaseRepository, IAchievementRepository
    {
        public AchievementRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Achievement>> ListAsync() 
        {
            return await _context.Achievements.ToListAsync();
        }
       
    }
}
