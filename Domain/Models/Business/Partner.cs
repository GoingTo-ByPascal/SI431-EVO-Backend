using GoingTo_API.Domain.Models.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Models.Business
{
    public class Partner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? PartnerProfileId { get; set; }
        public Promo Promo { get; set; }
        public PartnerProfile PartnerProfile { get; set; }
        public List<PartnerBenefits> PartnerBenefits { get; set; }
        public List<PartnerServices> PartnerServices { get; set; }
    }
}
