using GoingTo_API.Domain.Models.Geographic;
using GoingTo_API.Domain.Models.Accounts;
using GoingTo_API.Resources;
using GoingTo_API.Domain.Models;

namespace GoingTo_API.Mapping
{
    public class ModelToResourceProfile : AutoMapper.Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Locatable, LocatableResource>();
            CreateMap<User, UserResource>();
            CreateMap<Profile, ProfileResource>();
            CreateMap<Wallet, WalletResource>();
            CreateMap<Achievement, AchievementResource>();
            CreateMap<Country, CountryResource>();
            CreateMap<City, CityResource>();
            CreateMap<Place, PlaceResource>();
            CreateMap<Category, CategoryResource>();
            CreateMap<Review, ReviewResource>();
            CreateMap<Language, LanguageResource>();
            CreateMap<Currency, CurrencyResource>();
            CreateMap<Tip, TipResource>();
        }
    }
}
