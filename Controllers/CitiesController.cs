using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Services;
using GoingTo_API.Resources;
using Microsoft.AspNetCore.Mvc;

namespace GoingTo_API.Controllers
{
    [Route("/api/[Controller]")]
    public class CitiesController : Controller
    {
        private readonly ICityService _cityServices;
        private readonly IMapper _mapper;

        public CitiesController(ICityService cityServices, IMapper mapper)
        {
            _cityServices = cityServices;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CityResource>> GetAllAsync()
        {
            var cities = await _cityServices.ListAsync();
            var resources = _mapper.Map<IEnumerable<City>, IEnumerable<CityResource>>(cities);
            return resources;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var result = await _cityServices.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var cityResource = _mapper.Map<City, CityResource>(result.Resource);
            return Ok(cityResource);
        }
    }
}
