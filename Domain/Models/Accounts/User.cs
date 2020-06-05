using System.Collections.Generic;

namespace GoingTo_API.Domain.Models.Accounts
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Wallet Wallet { get; set; }

        public int WalletId { get; set; }
        public Profile Profile { get; set; }
        public IList<Review> Reviews { get; set; } = new List<Review>();
        public List<Favourite> Favourites { get; set; } = new List<Favourite>();
        public List<UserAchievement> UserAchievements { get; set; } = new List<UserAchievement>();
        public List<Tip> Tips { get; set; } = new List<Tip>();
        public List<UserPlan> UserPlans { get; set; }
    
    }
}
