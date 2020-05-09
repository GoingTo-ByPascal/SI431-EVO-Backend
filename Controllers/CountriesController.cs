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
    public class CountriesController : Controller
    {
        private readonly ICountryService _countryServices;
        private readonly IMapper _mapper;

        public CountriesController(ICountryService countryServices, IMapper mapper)
        {
            _countryServices = countryServices;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CountryResource>> GetAllAsync()
        {
            var countries = await _countryServices.ListAsync();
            var resources = _mapper.Map<IEnumerable<Country>, IEnumerable<CountryResource>>(countries);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {

            var result = await _countryServices.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var countryResource = _mapper.Map<Country, CountryResource>(result.Resource);
            return Ok(countryResource);
        }
    }
}
