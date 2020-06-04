using System.Collections.Generic;
using GoingTo_API.Domain.Models.Accounts;

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
        public IList<CountryCurrency> CountryCurrencies { get; set; }
        public IList<CountryLanguage> CountryLanguages { get; set; }


    }
}
