using GoingTo_API.Domain.Services;
using GoingTo_API.Extensions;
using GoingTo_API.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoingTo_API.Controllers
{
    [Route("/api/[controller]")]
    public class ProfilesController : Controller
    {
        private readonly IProfileService _profileService;
        private readonly AutoMapper.IMapper _mapper;

        public ProfilesController(IProfileService profileService, AutoMapper.IMapper mapper)
        {
            _profileService = profileService;
            _mapper = mapper;
        }

        //GET
        [HttpGet]
        public async Task<IEnumerable<ProfileResource>> GetAllAsync()
        {
            var profiles = await _profileService.ListAsync();
            var resource = _mapper.Map<IEnumerable<GoingTo_API.Domain.Models.Profile>, IEnumerable<ProfileResource>>(profiles);
            return resource;
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveProfileResource resource) // esto llega co un verbo post, y el body envia un objeto json 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages()); // el json cumple con los required ? No .. entonces badrequest
            var profile = _mapper.Map<SaveProfileResource, GoingTo_API.Domain.Models.Profile>(resource); // si cumple ... entonces , convertimos lo que llega a un objeto de la entidad
            var result = await _profileService.SaveAsync(profile); // espera el resultado de intentar grabar la entidad .. usando saveAsyn quien devuelve un save ___response, quien a su vez, por inyeccion crea el objeto

            if (!result.Success)
                return BadRequest(result.Message); // si no se puede grabar ... entonces badrequest

            var profileResource = _mapper.Map<GoingTo_API.Domain.Models.Profile, ProfileResource>(result.Profile); // pasamos el objeto a profileResource (quien controla lo que se puede mostrar) y retornamos un ok de que fue exitoso + los datos que queremos de mostrar de la entidad
            return Ok(profileResource);
        }

        //PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProfileResource resource)
        {
            var profile = _mapper.Map<SaveProfileResource, GoingTo_API.Domain.Models.Profile>(resource);
            var result = await _profileService.UpdateAsync(id, profile);

            if (!result.Success)
                return BadRequest(result.Message);

            var profileResource = _mapper.Map<GoingTo_API.Domain.Models.Profile, ProfileResource>(result.Profile);
            return Ok(profileResource);
        }


        //DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _profileService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var profileResource = _mapper.Map<GoingTo_API.Domain.Models.Profile, ProfileResource>(result.Profile);
            return Ok(profileResource);
        }
    }
}
