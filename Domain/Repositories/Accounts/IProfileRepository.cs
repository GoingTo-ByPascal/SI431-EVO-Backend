using GoingTo_API.Domain.Models.Accounts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Repositories.Accounts
{
    public interface IProfileRepository
    {
        Task<IEnumerable<Profile>> ListAsync(); 

        Task AddAsync(Profile profile); 

        Task<Profile> FindById(int id);
        void Update(Profile profile);

        void Remove(Profile profile); 
    }
}
