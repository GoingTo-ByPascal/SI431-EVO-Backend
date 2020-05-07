using System.Collections.Generic;
using System.Threading.Tasks;
using GoingTo_API.Domain.Models;

namespace GoingTo_API.Domain.Services
{
    public interface ICityServices
    {
        Task<IEnumerable<City>> ListAsync();
    }
}
