using GoingTo_API.Domain.Repositories;
using GoingTo_API.Domain.Services.Interactions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Controllers
{
    [Route("/api/users/{userId}/reviews")]
    [Produces("application/json")]
    public class UserReviewsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReviewService _reviewService;

        public UserReviewsController(IReviewService reviewService, IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
            _reviewService = reviewService;
        }

    }
}
