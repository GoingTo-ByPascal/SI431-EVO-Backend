using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Models.Geographic
{
    public class PlaceCategory
    {
        public int CategoriesId { get; set; }
        public Category Categories { get; set; }
        public int PlaceId { get; set; }
        public Place Place { get; set; }
    }
}
