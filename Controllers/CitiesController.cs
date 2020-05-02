using System.Collections.Generic;
using System.Threading.Tasks;
using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace GoingTo_API.Controllers
{
    [Route("/api/[Controller]")]
    public class CitiesController : Controller
    {
        private readonly ICityServices _cityServices;

        public CitiesController(ICityServices cityServices)
        {
            _cityServices = cityServices;
        }

        [HttpGet]
        public async Task<IEnumerable<City>> GetAllAsync()
        {
            var cities = await _cityServices.ListAsync();
            return cities;
        }
    }
}
