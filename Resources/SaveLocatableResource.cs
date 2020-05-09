using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Resources
{
    public class SaveLocatableResource
    {
        //under development, falta entrevistar a nuestros partners.
        [Required]
        [MaxLength(45)]
        public string Address { get; set; }
        public string Description { get; set; }
        [Required]
        public float Latitude { get; set; }
        [Required]
        public float Longitude { get; set; }

    }
}
