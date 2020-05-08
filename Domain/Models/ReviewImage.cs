using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Models
{
    public class ReviewImage
    {
        public int Id { get; set; }
        public string Filename { get; set; }
        public int ReviewId { get; set; }
        public Review Review { get; set; }
    }
}
