using AutoMapper;
using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Services;
using GoingTo_API.Extensions;
using GoingTo_API.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Controllers
{
    [Route("/api/[controller]")]
    public class AchievementController: Controller
    {
        private readonly IAchievementService _achievementService;
        private readonly IMapper _mapper;

        public AchievementController(IAchievementService achievementService, IMapper mapper)
        {
            _achievementService = achievementService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IEnumerable<AchievementResource>> GetAllAsync()
        {
            var achievements = await _achievementService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Achievement>, IEnumerable<AchievementResource>>(achievements);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveAchievementResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var tag = _mapper.Map<SaveAchievementResource, Achievement>(resource);
            var result = await _achievementService.SaveAsync(tag);

            if (!result.Success)
                return BadRequest(result.Message);

            var achievementResource = _mapper.Map<Achievement, AchievementResource>(result.Resource);
            return Ok(achievementResource);
        }


    }
}
