using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GoingTo_API.Resources
{
    public class SaveAchievementResource
    {
        [Required]
        [MaxLength(45)]
        public string Name { get; set; }
        public string Text { get; set; }
        public int Points { get; set; }
    }
}
