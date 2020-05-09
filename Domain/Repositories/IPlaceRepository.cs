using GoingTo_API.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Repositories
{
    public interface IPlaceRepository
    {
        Task<IEnumerable<Place>> ListAsync();
        Task<IEnumerable<Place>> ListByCityIdAsync(int cityId);
        Task<Place> FindById(int id);
        //Under development
        //Task AssignCityLocatable(int cityId,int locatableId,int id);
        Task AddAsync(Place place);
        void Update(Place place);
        void Remove(Place place);


    }
}
