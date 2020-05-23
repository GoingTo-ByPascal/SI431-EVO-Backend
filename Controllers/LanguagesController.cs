using AutoMapper;
using GoingTo_API.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Controllers
{
    public class LanguagesController: Controller
    {
        private readonly ILanguageService _languageService;
        private readonly IMapper _mapper;

        public LanguagesController(ILanguageService languageService, IMapper mapper)
        {
            _languageService = languageService;
            _mapper = mapper;
        }
    }
}
