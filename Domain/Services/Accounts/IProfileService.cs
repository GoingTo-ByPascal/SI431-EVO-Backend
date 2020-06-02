using GoingTo_API.Domain.Models;
using System.Collections.Generic;
using GoingTo_API.Domain.Services.Communications;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Services
{
    public interface IProfileService
    {
        Task<IEnumerable<Profile>> ListAsync();
        Task<ProfileResponse> SaveAsync(Profile profile);
        Task<ProfileResponse> UpdateAsync(int id, Profile profile);
        Task<ProfileResponse> DeleteAsync(int id);
    }
}
