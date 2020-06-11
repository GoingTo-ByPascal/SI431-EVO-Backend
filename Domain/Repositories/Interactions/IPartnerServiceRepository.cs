using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoingTo_API.Domain.Models.Interactions;

namespace GoingTo_API.Domain.Repositories.Interactions
{
    public interface IPartnerServiceRepository
    {
        Task<IEnumerable<PartnerService>> ListAsync();
        Task<IEnumerable<PartnerService>> ListByPartnerIdAsync(int partnerId);
        Task<IEnumerable<PartnerService>> ListByServiceIdAsync(int serviceId);
        Task<IEnumerable<PartnerService>> ListByLocatableIdAsync(int locatableId);
        Task<IEnumerable<PartnerService>> ListByLocatableIdAndPartnerIdAsync(int locatableId, int partnerId);
        Task<PartnerService> FindByPartenerIdLocatableIdAndServiceId(int locatableId, int partner, int serviceId);
        Task AddAsync(PartnerService partnerService);
        void Remove(PartnerService partnerService);
        Task AssignPartnerService(int locatableId, int partenerId,  int serviceId);
        void UnassignPartnerService(int locatableId, int partenerId,  int serviceId);

    }
}
