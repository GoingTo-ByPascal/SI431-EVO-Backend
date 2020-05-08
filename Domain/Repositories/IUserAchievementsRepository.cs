using GoingTo_API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Repositories
{
    public interface IUserAchievementsRepository
    {
        Task<IEnumerable<UserAchievements>> ListAsync();
        Task<IEnumerable<UserAchievements>> ListByUserIdAsync(int productId);
        Task<IEnumerable<UserAchievements>> ListByAchievementIdAsync(int tagId);
        Task<UserAchievements> FindByUserIdAndAchievementId(int productId, int tagId);
        Task AddAsync(UserAchievements userAchievements);
        void Remove(UserAchievements userAchievements);
        Task AssignUserAchievements(int userId, int achievementId);
        void UnassignUserAchievements(int userId, int achievementId);
    }
}
