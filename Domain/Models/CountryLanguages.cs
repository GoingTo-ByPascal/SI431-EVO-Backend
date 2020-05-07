using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Models
{
    public class CountryLanguages
    {
        public int Id { get; set; }

        public Country Country { get; set; }
        public int country_id { get; set; }

        public Language Language { get; set; }
        public int language_id { get; set; }
    }
}
