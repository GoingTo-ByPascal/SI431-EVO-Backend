using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Models
{
    public class ReviewImage
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public int RewiewId { get; set; }
        public Review Review { get; set; }
    }
}
