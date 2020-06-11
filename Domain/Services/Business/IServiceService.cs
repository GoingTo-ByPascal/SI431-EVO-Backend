using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoingTo_API.Domain.Models.Business;
using GoingTo_API.Domain.Services.Communications;

namespace GoingTo_API.Domain.Services.Business
{
    public interface IServiceService
    {
        Task<IEnumerable<Service>> ListAllAsync();
        Task<IEnumerable<Service>> ListByPartnerIdAndLocatableIdAsync(int partnerId, int locatableId);
        Task<ServiceResponse> GetByIdAsync(int serviceId);
        Task<ServiceResponse> SaveAsync(Service service);
        Task<ServiceResponse> UpdateAsync(int serviceId, Service service);
        Task<ServiceResponse> DeleteAsync(int serviceId);
    }
}
