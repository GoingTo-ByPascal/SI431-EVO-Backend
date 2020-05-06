using GoingTo_API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Resources
{
    public class UserResource
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int Password { get; set; }
        public Wallet Wallet { get; set; }
    //    public IList<Favourite> Favourites { get; set; } = new List<Favourite>();
    //    public ICollection<UserAchievements> UserAchievements { get; set; } = new HashSet<UserAchievements>();
    }
}
