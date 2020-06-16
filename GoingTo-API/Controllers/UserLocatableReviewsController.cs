using AutoMapper;
using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Services;
using GoingTo_API.Domain.Services.Accounts;
using GoingTo_API.Domain.Services.Interactions;
using GoingTo_API.Extensions;
using GoingTo_API.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Controllers
{   [Route("/api/user/{userId}/locatable/{locatableId}/reviews")]
    public class UserLocatableReviewsController:Controller
    {
        private readonly IReviewService _reviewService;
        private readonly ILocatableService _locatableService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserLocatableReviewsController(IReviewService reviewService, ILocatableService locatableService, IUserService userService, IMapper mapper)
        {
            _reviewService = reviewService;
            _locatableService = locatableService;
            _userService = userService;
            _mapper = mapper;
        }

        /// <summary>
        /// creates a review for a Locatable in the system.
        /// </summary>
        /// <param name="locatableId"></param>
        /// <param name="resource"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync(int locatableId, [FromBody] SaveReviewResource resource, int userId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var existingLocatable = await _locatableService.GetByIdAsync(locatableId);
            var existingUser = await _userService.GetByIdAsync(userId);
            if (!existingLocatable.Success)
                return BadRequest(existingLocatable.Message);
            if (!existingUser.Success)
                return BadRequest(existingUser.Message);

            var review = _mapper.Map<SaveReviewResource, Review>(resource);
            review.Locatable = existingLocatable.Resource;
            review.User = existingUser.Resource;

            var result = await _reviewService.SaveAsync(review);

            if (!result.Success)
                return BadRequest(result.Message);

            var reviewResource = _mapper.Map<Review, ReviewResource>(result.Resource);
            return Ok(reviewResource);
        }

        /// <summary>
        /// allows to change the Comment and Stars an existing Review
        /// </summary>
        /// <param name="locatableId"></param>
        /// <param name="reviewId">the id of the Review to update</param>
        /// <param name="resource"></param>
        /// <returns></returns>
        [HttpPut("{reviewId}")]
        public async Task<IActionResult> PutAsync(int locatableId, int reviewId, [FromBody] SaveReviewResource resource)
        {
            var existingLocatable = await _locatableService.GetByIdAsync(locatableId);
            if (!existingLocatable.Success)
                return BadRequest(existingLocatable.Message);

            var review = _mapper.Map<SaveReviewResource, Review>(resource);
            var result = await _reviewService.UpdateAsync(reviewId, review);

            if (!result.Success)
                return BadRequest(result.Message);

            var reviewResource = _mapper.Map<Review, ReviewResource>(result.Resource);
            return Ok(reviewResource);
        }

        /// <summary>
        /// delete a review from one locatable
        /// </summary>
        /// <param name="locatableId"></param>
        /// <param name="reviewId"></param>
        /// <response code="204">the review was unasigned successfully</response>
        /// <returns></returns>
        [HttpDelete("{reviewId}")]
        public async Task<IActionResult> DeleteAsync(int locatableId, int reviewId)
        {
            var existingLocatable = await _locatableService.GetByIdAsync(locatableId);
            if (!existingLocatable.Success)
                return BadRequest(existingLocatable.Message);

            var result = await _reviewService.DeleteAsync(reviewId);

            if (!result.Success)
                return BadRequest(result.Message);

            var reviewResource = _mapper.Map<Review, ReviewResource>(result.Resource);
            return Ok(reviewResource);
        }
    
    }
}
