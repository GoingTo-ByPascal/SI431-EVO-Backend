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

        public int LocatableId { get; set; }
        public Locatable Locatable { get; set; }
        public IList<Profile> Profiles { get; set; } = new List<Profile>();
        public IList<City> Cities { get; set; } = new List<City>();
        public IList<CountryCurrencies> CountryCurrencies { get; set; }
        public IList<CountryLanguages> CountryLanguages { get; set; }

    }
}
