using System;
using AutoMapper;
using GoingTo_API.Domain.Services;
using GoingTo_API.Domain.Services.Geographic;
using Microsoft.AspNetCore.Mvc;

namespace GoingTo_API.Controllers
{
    [Route("/api/locatables/{locatableId}/tips")]
    public class LocatableTipsController : Controller
    {
        private readonly ILocatableService _locatableService;
        private readonly ITipService _tipService;
        private readonly IMapper _mapper;

        public LocatableTipsController(ILocatableService locatableService,ITipService tipService,IMapper mapper)
        {
            _locatableService = locatableService;
            _tipService = tipService;
            _mapper = mapper;
        }

    }
}
