using GoingTo_API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Services
{
    public interface IAchievementService
    {
        Task<IEnumerable<Achievement>> ListAsync();
    }
}
