using System;
using GoingTo_API.Domain.Models.Interactions;

namespace GoingTo_API.Domain.Services.Communications
{
    public class PartnerServiceResponse : BaseResponse<PartnerService>
    {
        public PartnerServiceResponse(PartnerService partnerService) : base(partnerService)
        {
        }
        public PartnerServiceResponse(string message) : base(message)
        {
        }
    }
}
