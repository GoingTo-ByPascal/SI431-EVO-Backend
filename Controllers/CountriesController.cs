using System.Collections.Generic;
using System.Threading.Tasks;
using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace GoingTo_API.Controllers
{
    [Route("/api/[Controller]")]
    public class CountriesController : Controller
    {
        private readonly ICountryServices _countryServices;

        public CountriesController(ICountryServices countryServices)
        {
            _countryServices = countryServices;
        }

        [HttpGet]
        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            var countries = await _countryServices.ListAsync();
            return countries;
        }
    }
}
