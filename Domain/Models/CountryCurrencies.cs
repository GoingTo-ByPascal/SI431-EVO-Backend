using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Models
{
    public class CountryCurrencies
    {
        public int Id { get; set; }
        
        public Country Country { get; set; }
        public int country_id { get; set; }

        public Currency Currency { get; set; }
        public int currency_id { get; set; }
    }
}
