using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoingTo_API.Domain.Models.Interactions;
using GoingTo_API.Domain.Persistence.Context;
using GoingTo_API.Domain.Repositories.Interactions;
using Microsoft.EntityFrameworkCore;

namespace GoingTo_API.Persistence.Repositories
{
    public class PartnerServiceRepository : BaseRepository, IPartnerServiceRepository
    {
        public PartnerServiceRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(PartnerService partnerService)
        {
            await _context.PartnerServices.AddAsync(partnerService);
        }

        public async Task AssignPartnerService(int locatableId,int partenerId,int serviceId)
        {
            PartnerService partnerService = await FindByPartenerIdLocatableIdAndServiceId(locatableId, partenerId, serviceId);
            if(partnerService==null)
            {
                partnerService = new PartnerService { LocatableId = locatableId, PartnerId = partenerId, ServiceId = serviceId };
                await AddAsync(partnerService);
            }
        }

        public async Task<PartnerService> FindByPartenerIdLocatableIdAndServiceId(int locatableId, int partnerId,int serviceId)
        {
            return await _context.PartnerServices.FindAsync(locatableId, partnerId, serviceId);
        }

        public async Task<IEnumerable<PartnerService>> ListAsync()
        {
            return await _context.PartnerServices
                .Include(p => p.Service)
                .Include(p => p.Locatable)
                .Include(p => p.Partner)
                .ToListAsync();
                
        }

        public async Task<IEnumerable<PartnerService>> ListByLocatableIdAndPartnerIdAsync(int locatableId, int partnerId)
        {
            return await _context.PartnerServices
                .Where(p=>p.LocatableId==locatableId)
                .Where(p=>p.PartnerId==partnerId)
                .Include(p => p.Locatable)
                .Include(p => p.Partner)
                .ToListAsync();

        }

        public async Task<IEnumerable<PartnerService>> ListByLocatableIdAsync(int locatableId)
        {
            return await _context.PartnerServices
                .Where(p=>p.LocatableId==locatableId)
                .Include(p => p.Locatable)
                .Include(p => p.Partner)
                .ToListAsync();

        }
        public async Task<IEnumerable<PartnerService>> ListByPartnerIdAsync(int partnerId)
        {
            return await _context.PartnerServices
                .Where(p=>p.PartnerId==partnerId)
                .Include(p => p.Locatable)
                .Include(p => p.Partner)
                .ToListAsync();

        }

        public async Task<IEnumerable<PartnerService>> ListByServiceIdAsync(int serviceId)
        {
            return await _context.PartnerServices
                .Where(p=>p.ServiceId==serviceId)
                .Include(p => p.Locatable)
                .Include(p => p.Partner)
                .ToListAsync();

        }

        public void Remove(PartnerService partnerService)
        {
            _context.Remove(partnerService);
        }

        public async void UnassignPartnerService(int locatableId, int partenerId, int serviceId)
        {
            PartnerService partnerService = await FindByPartenerIdLocatableIdAndServiceId(locatableId, partenerId, serviceId);
            if(partnerService!=null)
            {
                Remove(partnerService);
            }
        }
    }
}
