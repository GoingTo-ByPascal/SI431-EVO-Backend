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
        public string ReviewAt { get; set; }
        public Reviewable Reviewable { get; set; }
        public User User { get; set; }
    }
}
