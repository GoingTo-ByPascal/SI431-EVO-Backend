using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Services;
using GoingTo_API.Resources;
using GoingTo_API.Services;

namespace GoingTo_API.Controllers
{
    [Route("/api/users/{userId}/achievements")]
    public class UserAchievementController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserAchievementService _userAchievementService;
        private readonly IAchievementService _achievementService;

        public UserAchievementController(IAchievementService achievementService ,IUserAchievementService userAchievementService, IMapper mapper)
        {
            _achievementService = achievementService; 
            _mapper = mapper;
            _userAchievementService = userAchievementService;
        }

        [HttpGet]
        public async Task<IEnumerable<AchievementResource>> GetAllByUserIdAsync(int userId)
        {
            var achievements = await _achievementService.ListByUserIdAsync(userId);
            var resources = _mapper
                .Map<IEnumerable<Achievement>, IEnumerable<AchievementResource>>(achievements);
            return resources;
        }

        [HttpPost("{achievementId}")]
        public async Task<IActionResult> AssignUserAchievement(int userId, int achievementId)
        {

            var result = await _userAchievementService.AssignUserAchievement(userId, achievementId);
            if (!result.Success)
                return BadRequest(result.Message);

            var achievementResource = _mapper.Map<Achievement, AchievementResource>(result.Resource.Achievement);
            return Ok(achievementResource);

        }

    }
}