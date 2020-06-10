using GoingTo_API.Domain.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Models.Interactions
{
    public class PartnerService
    {
        public int Id { get; set; }
        public float Points { get; set; }
        public Service Service { get; set; }
        public int ServiceId { get; set; }
        public Partner Partner { get; set; }
        public int PartnerId { get; set; }
        public Locatable Locatable { get; set; }
        public int LocatableId { get; set; }
    }
}
