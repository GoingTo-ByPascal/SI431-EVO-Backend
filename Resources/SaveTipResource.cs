using System;
using System.ComponentModel.DataAnnotations;
using GoingTo_API.Domain.Models;

namespace GoingTo_API.Resources
{
    public class SaveTipResource
    {
        [Required]
        [MaxLength(140)]
        public string Text { get; set; }
    }
}
