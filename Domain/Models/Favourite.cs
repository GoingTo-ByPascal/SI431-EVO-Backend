using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Models
{
    public class Favourite
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        
        public User User;

        public Locatable Locatable;
        public int LocatableId { get; set; }
    }
}
