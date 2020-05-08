using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Services
{
    public interface IUserAchievementService
    {
        Task<IEnumerable<UserAchievement>> ListAsync();
        Task<IEnumerable<UserAchievement>> ListByUserIdAsync(int userId);
        Task<IEnumerable<UserAchievement>> ListByAchievementIdAsync(int achievementId);
        Task<UserAchievementResponse> AssignUserAchievement(int userId, int achievementId);
        Task<UserAchievementResponse> UnassignUserAchievement(int userId, int achievementId);
    }
}
