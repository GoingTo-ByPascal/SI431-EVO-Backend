using System;
using System.ComponentModel.DataAnnotations;
using GoingTo_API.Domain.Models;

namespace GoingTo_API.Resources
{
    public class SaveTipResource
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(45)]
        public string Text { get; set; }
        [Required]
        public Locatable Locatable { get; set; }
    }
}
