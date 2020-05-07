using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Models
{
    public class Place
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Stars { get; set; }
        public int city_id { get; set; }
        public City City { get; set; }

        public int locatable_id { get; set; }
        public Locatable Locatable { get; set; }
    }
}
