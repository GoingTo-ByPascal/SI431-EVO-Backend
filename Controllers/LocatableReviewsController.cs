using AutoMapper;
using GoingTo_API.Domain.Services.Interactions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Controllers
{
    //FALTA
    public class LocatableReviewsController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly IMapper _mapper;

        public LocatableReviewsController(IReviewService reviewService, IMapper mapper) 
        {
            _reviewService = reviewService;
            _mapper = mapper;
        }

    }
}
