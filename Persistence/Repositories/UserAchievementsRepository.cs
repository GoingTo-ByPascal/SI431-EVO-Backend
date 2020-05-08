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
    public class UserAchievementsRepository : BaseRepository, IUserAchievementsRepository
    {
        public UserAchievementsRepository(AppDbContext context) : base(context) { }
       
        //LISTO
        public async Task AddAsync(UserAchievements userAchievements)
        {
            await _context.UserAchievements.AddAsync(userAchievements);
        }

        //LISTO
        public async Task AssignUserAchievements(int userId, int achievementId)
        {

            UserAchievements userAchievements = await FindByUserIdAndAchievementId(userId, achievementId);
            if (userAchievements == null) 
            {
                userAchievements = new UserAchievements { UserId = userId, AchievementId = achievementId };
                await AddAsync(userAchievements);
            }        
        }

        //LISTO
        public async Task<UserAchievements> FindByUserIdAndAchievementId(int userId, int achievementId)
        {
            return await _context.UserAchievements.FindAsync(userId, achievementId);
        }

        //LISTO
        public async Task<IEnumerable<UserAchievements>> ListAsync()
        {
            return await _context.UserAchievements
                .Include(ua => ua.User)
                .Include(ua => ua.Achievement)
                .ToListAsync();
        }

        //LISTO
        public async Task<IEnumerable<UserAchievements>> ListByUserIdAsync(int userId)
        {
            return await _context.UserAchievements
                .Where(ua => ua.UserId == userId)
                .Include(ua => ua.User)
                .Include(ua => ua.Achievement)
                .ToListAsync();
        }

        //LISTO
        public async Task<IEnumerable<UserAchievements>> ListByAchievementIdAsync(int achievementId)
        {
            return await _context.UserAchievements
                .Where(ua => ua.AchievementId == achievementId)
                .Include(ua => ua.User)
                .Include(ua => ua.Achievement)
                .ToListAsync();
        }

        //LISTO
        public void Remove(UserAchievements userAchievements)
        {
            _context.UserAchievements.Remove(userAchievements);
        }

        //LISTO
        public async void UnassignUserAchievements(int userId, int achievementId)
        {
            UserAchievements userAchievements = await FindByUserIdAndAchievementId(userId, achievementId);
            if (userAchievements != null)
            {
                Remove(userAchievements);
            }
        }
    }
}
