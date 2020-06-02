using AutoMapper;
using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Models.Geographic;
using GoingTo_API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Mapping
{
    public class ResourceToModelProfile : AutoMapper.Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveUserResource, User>();
            CreateMap<SaveAchievementResource, Achievement>();
            CreateMap<SavePlaceResource, Place>();
            CreateMap<SaveCategoryResource, Category>();
            CreateMap<SaveReviewResource, Review>();
            CreateMap<SaveLanguageResource, Language>();
            CreateMap<SaveCurrencyResource, Currency>();
            CreateMap<SaveTipResource, Tip>();
        }
    }
}
