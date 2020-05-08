using System.Collections.Generic;
using System.Threading.Tasks;
using GoingTo_API.Domain.Models;

namespace GoingTo_API.Domain.Repositories
{
    public interface IAchievementRepository
    {
        Task<IEnumerable<Achievement>> ListAsync();
    }
}
