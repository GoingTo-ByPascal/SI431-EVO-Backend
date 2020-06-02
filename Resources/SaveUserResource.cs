using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Resources
{
    public class SaveUserResource
    {
        [Required]
        [MaxLength(45)]
        public string Email { get; set; }

        [Required]
        [MaxLength(45)]
        public int Password { get; set; }
    }
}
