using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoingTo_API.Domain.Models.Interactions;
using GoingTo_API.Domain.Services.Communications;

namespace GoingTo_API.Domain.Services.Interactions
{
    public interface IPartnerServiceService
    {
        Task<IEnumerable<PartnerService>> ListAsync();
        Task<IEnumerable<PartnerService>> ListByLocatableIdAsync(int locatableId);
        Task<IEnumerable<PartnerService>> ListByPartnerIdAsync(int partnerId);
        Task<IEnumerable<PartnerService>> ListByServiceIdAsync(int serviceId);
        Task<IEnumerable<PartnerService>> ListByPartnerIdAndLocatableId(int partnerId,int locatableId);
        Task<PartnerServiceResponse> AssignPartnerServiceAsync(int locatableId, int partenerId, int serviceId);
        Task<PartnerServiceResponse> UnassignPartnerServiceAsync(int locatableId, int partenerId, int serviceId);
    }
}
