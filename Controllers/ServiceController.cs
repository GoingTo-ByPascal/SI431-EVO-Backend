using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GoingTo_API.Domain.Models.Business;
using GoingTo_API.Domain.Services.Business;
using GoingTo_API.Extensions;
using GoingTo_API.Resources;
using GoingTo_API.Resources.SaveResources;
using Microsoft.AspNetCore.Mvc;

namespace GoingTo_API.Controllers
{
    [Route("/api/services")]
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;
        private readonly IMapper _mapper;

        public ServiceController(IServiceService serviceService, IMapper mapper)
        {
            _serviceService = serviceService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var services = await _serviceService.ListAllAsync();
            if(services==null)
                return BadRequest(ModelState.GetErrorMessages());
            var resources = _mapper.Map<IEnumerable<Service>, IEnumerable<ServiceResource>>(services);
            return Ok(resources);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int serviceId)
        {
            var service = await _serviceService.GetByIdAsync(serviceId);
            if (service == null)
                return BadRequest(ModelState.GetErrorMessages());
            var resource = _mapper.Map<Service, ServiceResource>(service.Resource);
            return Ok(resource);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]SaveServiceResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var service = _mapper.Map<SaveServiceResource, Service>(resource);
            var result = await _serviceService.SaveAsync(service);

            if (!result.Success)
                return BadRequest(ModelState.GetEnumerator());
            var serviceResource = _mapper.Map<Service, ServiceResource>(result.Resource);
            return Ok(serviceResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromBody] SaveServiceResource resource, int id )
        {
            var service = _mapper.Map<SaveServiceResource, Service>(resource);
            var result = await _serviceService.UpdateAsync(id,service);

            if (!result.Success)
                return BadRequest(ModelState.GetErrorMessages());

            var serviceResource = _mapper.Map<Service, ServiceResource>(result.Resource);
            return Ok(serviceResource);
            
        }

    }
}
