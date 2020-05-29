using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Services.Interactions
{
    public interface IReviewService
    {
        Task<ReviewResponse> SaveAsync(Review review);
        Task<ReviewResponse> UpdateAsync(int id, Review review);
        Task<ReviewResponse> DeleteAsync(int id);
        Task<ReviewResponse> GetByIdAsync(int id);
        Task<IEnumerable<Review>> ListAsync();
        Task<IEnumerable<Review>> ListByUserIdAsync(int userId);


    }
}
