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
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public List<Tip> Tips { get; set; }
        public int ReviewableId { get; set; }
        public Reviewable Reviewable { get; set; }
        public Favourite Favourite { get; set; }
        public City City { get; set; }
        public Country Country { get; set; }
        public Place Place { get; set; }


    }
}
