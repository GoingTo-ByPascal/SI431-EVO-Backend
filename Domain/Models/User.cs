using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Wallet Wallet { get; set; }
        public int wallet_id { get; set; }
        public Profile Profile { get; set; }
        public List<Review> Reviews { get; set; } = new List<Review>();
        public List<Favourite> Favourites { get; set; } = new List<Favourite>();
        public List<UserAchievements> UserAchievements { get; set; } = new List<UserAchievements>();

    
    }
}
