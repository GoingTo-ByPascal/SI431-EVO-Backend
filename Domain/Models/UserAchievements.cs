using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Models
{
    public class UserAchievements
    {
        public int Id { get; set; }
        public int user_id { get; set; }
        public int AchievementId { get; set; }
        public User User { get; set; }
        public Achievement Achievement { get; set; }
    }
}
