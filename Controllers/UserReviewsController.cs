using AutoMapper;
using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Repositories;
using GoingTo_API.Domain.Services.Interactions;
using GoingTo_API.Resources;
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
        private readonly IMapper _mapper;
        private readonly IReviewService _reviewService;

        public UserReviewsController(IReviewService reviewService, IMapper mapper) 
        {
            _mapper = mapper;
            _reviewService = reviewService;
        }
        /// <summary>
        /// Returns all the reviews of a user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<ReviewResource>> GetAllByUserIdAsync(int userId)
        {
            var reviews = await _reviewService.ListByUserIdAsync(userId);
            var resources = _mapper.Map<IEnumerable<Review>, IEnumerable<ReviewResource>>(reviews);
            return resources;
        }
    }
}
