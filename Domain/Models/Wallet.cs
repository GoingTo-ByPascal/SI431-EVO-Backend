using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Models
{
    public class Wallet
    {
        public int Id { get; set; }
        public int Points { get; set; }
        public User User{get;set;}
    }
}
