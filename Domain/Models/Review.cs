using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public float Stars { get; set; }
        public string ReviewedAt { get; set; }
        public int reviewable_id { get; set; }
        public Reviewable Reviewable { get; set; }
        public int user_id { get; set; }
        public User User { get; set; }
        public List<ReviewImage> ReviewImages { get; set; } = new List<ReviewImage>();
    }
}
