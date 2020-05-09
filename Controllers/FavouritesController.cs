using AutoMapper;
using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Services;
using GoingTo_API.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Controllers
{
    [Route("/api/users/{userId}/locatables")]
    public class FavouritesController :Controller
    {
        private readonly ILocatableService _locatableService;
        private readonly IFavouriteService _favouriteService;
        private readonly IMapper _mapper;

        public FavouritesController(ILocatableService locatableService,IFavouriteService favouriteService, IMapper mapper)
        {
            _locatableService = locatableService;
            _favouriteService = favouriteService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<LocatableResource>> GetAllByUserIdAsync(int userId)
        {
            var locatables = await _locatableService.ListByUserIdAsync(userId);
            var resources = _mapper.Map<IEnumerable<Locatable>, IEnumerable<LocatableResource>>(locatables);
            return resources;
        }

        [HttpPost("{locatableId}")]
        public async Task<IActionResult> AssignFavourite(int userId, int locatableId)
        {
            var result = await _favouriteService.AssignFavouriteAsync(userId, locatableId);
            if (!result.Success)
                return BadRequest(result.Message);
            var locatableResource = _mapper.Map<Locatable, LocatableResource>(result.Resource.Locatable);
            return Ok(locatableResource);
        }
    }
}
