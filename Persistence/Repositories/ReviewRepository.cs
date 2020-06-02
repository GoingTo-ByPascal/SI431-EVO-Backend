using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Persistence.Context;
using GoingTo_API.Domain.Repositories.Interactions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Persistence.Repositories
{
    public class ReviewRepository : BaseRepository, IReviewRepository
    {
        public ReviewRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Review review)
        {
           await _context.Reviews.AddAsync(review);
        }
        public void Remove(Review review)
        {
            _context.Reviews.Remove(review);
        }

        public void Update(Review review)
        {
            _context.Reviews.Update(review);
        }
        public async Task<Review> FindById(int id)
        {
            return await _context.Reviews.FindAsync(id);
        }

        public async Task<IEnumerable<Review>> ListAsync()
        {
            return await _context.Reviews.ToListAsync();
        }

        public async Task<IEnumerable<Review>> ListByUserIdAsync(int userId) =>
            await _context.Reviews
            .Where(p => p.UserId == userId)
            .Include(p => p.User)
            .ToListAsync();



    }
}
