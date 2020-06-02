using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Birthdate { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
