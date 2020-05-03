using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int Password { get; set; }
        public Wallet Wallets { get; set; }
    }
}
