using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Repositories;
using GoingTo_API.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Services
{
    public class AchievementService : IAchievementService

    {
        private readonly IAchievementRepository _achievementRepository;
        private readonly IUnitOfWork _unitOfWork;

        public async Task<IEnumerable<Achievement>> ListAsync()
        {
            return await _achievementRepository.ListAsync();
        }
    }
}
