using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Resources
{
    public class PlaceResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Stars { get; set; }

        public LocatableResource Locatable { get; set; }

        public CityResource City { get; set; } 

        //public CountryResource Country { get; set; } //Creo que no es necsario ya que desde el repository se llama
    }
}
