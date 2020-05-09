using AutoMapper;
using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Repositories;
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
    public class PlacesController : Controller
    {
        private readonly IPlaceService _placeService;
        private readonly IMapper _mapper;

        public PlacesController(IPlaceService placeService, IMapper mapper)
        {
            _mapper = mapper;
            _placeService = placeService;
        }

        [HttpGet]
        public async Task<IEnumerable<PlaceResource>> GetAllAsync()
        {
            var places = await _placeService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Place>, IEnumerable<PlaceResource>>(places);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePlaceResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var place = _mapper.Map<SavePlaceResource, Place>(resource);
            var result = await _placeService.SaveAsync(place);

            if (!result.Success)
                return BadRequest(result.Message);

            var placeResource = _mapper.Map<Place, PlaceResource>(result.Resource);
            return Ok(placeResource);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            var result = await _placeService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var placeResource = _mapper.Map<Place, PlaceResource>(result.Resource);
            return Ok(placeResource);
        }

    }
}
