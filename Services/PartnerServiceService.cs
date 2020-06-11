using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoingTo_API.Domain.Repositories;
using GoingTo_API.Domain.Repositories.Interactions;
using GoingTo_API.Domain.Services.Communications;
using GoingTo_API.Domain.Services.Interactions;

namespace GoingTo_API.Services
{
    public class PartnerServiceService : IPartnerServiceService
    {
        private readonly IPartnerServiceRepository _partnerServiceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PartnerServiceService(IPartnerServiceRepository partnerServiceRepository, IUnitOfWork unitOfWork) 
        {
            _partnerServiceRepository = partnerServiceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<PartnerServiceResponse> AssignPartnerServiceAsync(int locatableId, int partenerId, int serviceId)
        {
            try
            {
                await _partnerServiceRepository.AssignPartnerService(locatableId, partenerId, serviceId);
                await _unitOfWork.CompleteAsync();
                Domain.Models.Interactions.PartnerService partnerService = await _partnerServiceRepository.FindByPartenerIdLocatableIdAndServiceId(locatableId,partenerId,serviceId);
                return new PartnerServiceResponse(partnerService);
            }
            catch(Exception ex)
            {
                return new PartnerServiceResponse($"An error ocurred while assigning Service to Locatable: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Domain.Models.Interactions.PartnerService>> ListAsync()
        {
            return await _partnerServiceRepository.ListAsync();
        }

        public async Task<IEnumerable<Domain.Models.Interactions.PartnerService>> ListByLocatableIdAsync(int locatableId)
        {
            return await _partnerServiceRepository.ListByLocatableIdAsync(locatableId);
        }

        public async Task<IEnumerable<Domain.Models.Interactions.PartnerService>> ListByPartnerIdAndLocatableId(int partnerId, int locatableId)
        {
            return await _partnerServiceRepository.ListByLocatableIdAndPartnerIdAsync(partnerId, locatableId);
        }

        public async Task<IEnumerable<Domain.Models.Interactions.PartnerService>> ListByPartnerIdAsync(int partnerId)
        {
            return await _partnerServiceRepository.ListByPartnerIdAsync(partnerId);
        }

        public async Task<IEnumerable<Domain.Models.Interactions.PartnerService>> ListByServiceIdAsync(int serviceId)
        {
            return await _partnerServiceRepository.ListByServiceIdAsync(serviceId);
        }

        public async Task<PartnerServiceResponse> UnassignPartnerServiceAsync(int locatableId, int partenerId, int serviceId)
        {
            try
            {
                Domain.Models.Interactions.PartnerService partnerService = await _partnerServiceRepository.FindByPartenerIdLocatableIdAndServiceId(locatableId, partenerId, serviceId);
                _partnerServiceRepository.Remove(partnerService);
                await _unitOfWork.CompleteAsync();
                return new PartnerServiceResponse(partnerService);
            }
            catch (Exception ex)
            {
                return new PartnerServiceResponse($"An error ocurred while unassigning Service to Locatable: {ex.Message}");
            }
        }
    }
}
