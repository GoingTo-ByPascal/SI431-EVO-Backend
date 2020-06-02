using GoingTo_API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Repositories.Interactions
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> ListAsync();
        Task<IEnumerable<Review>> ListByUserIdAsync(int userId);
        Task AddAsync(Review review);
        Task<Review> FindById(int id);
        void Update(Review review);
        void Remove(Review review);
    }
}
