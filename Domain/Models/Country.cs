using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public List<City> Cities { get; set; } = new List<City>();
        public int locatable_id { get; set; }
        public Locatable Locatable { get; set; }
        public List<Profile> Profiles { get; set; } = new List<Profile>();
        public List<CountryCurrencies> CountryCurrencies { get; set; }
        public List<CountryLanguages> CountryLanguages { get; set; }
    }
}
