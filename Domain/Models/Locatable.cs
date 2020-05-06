using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Models
{
    public class Locatable
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public IList<Tip> Tips { get; set; }
        public int ReviewableId { get; set; }
        public Reviewable Reviewable { get; set; }
        public List<Favourite> Favourites { get; set; }
        public City City { get; set; }
        public Country Country { get; set; }
        public Place Place { get; set; }

    }
}
