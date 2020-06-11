using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GoingTo_API.Domain.Models.Business;
using GoingTo_API.Domain.Services;
using GoingTo_API.Domain.Services.Accounts;
using GoingTo_API.Domain.Services.Business;
using GoingTo_API.Domain.Services.Interactions;
using GoingTo_API.Extensions;
using GoingTo_API.Resources;
using Microsoft.AspNetCore.Mvc;

namespace GoingTo_API.Controllers
{
    [Route("/api/partners/{partnerId}/locatable/{locatableId}/services")]
    public class PartnerServicesController : Controller
    {
        private readonly IServiceService _serviceService;
        private readonly IPartnerServiceService _partnerServiceService;
        private readonly IMapper _mapper;

        public PartnerServicesController(IServiceService serviceService, IPartnerServiceService partnerServiceService, IMapper mapper)
        {
            _serviceService = serviceService;
            _partnerServiceService = partnerServiceService;
            _mapper = mapper;
        }



        /// <summary>
        /// returns services by partner and locatables in the system
        /// </summary>
        /// <param name="partnerId"></param>
        /// <param name="locatableId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetServicesByPartnerIdAndLocatableId(int partnerId, int locatableId)
        {
            var services = await _serviceService.ListByPartnerIdAndLocatableIdAsync(partnerId, locatableId);
            if (services == null)
                return BadRequest(ModelState.GetErrorMessages());
            var resources = _mapper.Map<IEnumerable<Service>, IEnumerable<ServiceResource>>(services);
            return Ok(resources);
        }

        /// <summary>
        /// assign a service to a partner in the system
        /// </summary>
        /// <param name="partnerId"></param>
        /// <param name="locatableId"></param>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        [HttpPost("{serviceId}")]
        public async Task<IActionResult> AssignPartnerService(int partnerId,int locatableId, int serviceId)
        {
            var result = await _partnerServiceService.AssignPartnerServiceAsync(partnerId, locatableId, serviceId);
            if (!result.Success)
                return BadRequest(ModelState.GetErrorMessages());

            var partnerService = _mapper.Map<Service, ServiceResource>(result.Resource.Service);
            return Ok(partnerService);
        }

        /// <summary>
        /// unassign a service to a partner in the system
        /// </summary>
        /// <param name="partnerId"></param>
        /// <param name="locatableId"></param>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        [HttpDelete("{serviceId}")]
        public async Task<IActionResult> UnassignPartnerService(int partnerId, int locatableId, int serviceId)
        {
            var existingService = await _serviceService.GetByIdAsync(serviceId);
            if (existingService == null)
                return BadRequest(ModelState.GetErrorMessages());
            var result = await _partnerServiceService.UnassignPartnerServiceAsync(partnerId, locatableId, serviceId);
            var resource = _mapper.Map<Service, ServiceResource>(result.Resource.Service);
            return Ok(resource);
        }


    }
}
