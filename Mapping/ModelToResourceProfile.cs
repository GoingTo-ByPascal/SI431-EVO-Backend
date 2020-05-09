
using GoingTo_API.Domain.Models;
using GoingTo_API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Mapping
{
    public class ModelToResourceProfile : AutoMapper.Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Locatable, LocatableResource>();
            CreateMap<User, UserResource>();
            CreateMap<Wallet, WalletResource>();
            CreateMap<Reviewable, ReviewableResource>();
            CreateMap<Country, CountryResource>();
            CreateMap<City, CityResource>();
            CreateMap<Place, PlaceResource>();
        }
    }
}
