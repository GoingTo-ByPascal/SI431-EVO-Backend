using AutoMapper;
using GoingTo_API.Domain.Services.Geographic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Controllers
{
    public class CountryLanguagesController : Controller
    {

        private readonly IMapper _mapper;
        private readonly ICountryLanguageService _countryLanguageService;

        public CountryLanguagesController(ICountryLanguageService countryLanguageService, IMapper mapper)
        {
            _mapper = mapper;
            _countryLanguageService = countryLanguageService;
        }
    }
}
