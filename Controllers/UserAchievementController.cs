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
    [Route("/api/[controller]")]
    public class UserAchievementController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserAchievementService _userAchievementService;

        public UserAchievementController(IUserAchievementService UserAchievementService, IMapper mapper)
        {
            _mapper = mapper;
            _userAchievementService = UserAchievementService;
        }

        //[HttpGet]
        //public async Task<IEnumerable<UserAchievementResource>> GetAllAsync()
        //{
        //    var locatables = await _locatableService.ListAsync();
        //    var resources = _mapper
        //        .Map<IEnumerable<Locatable>, IEnumerable<LocatableResource>>(locatables);
        //    return resources;
        }

    }
}