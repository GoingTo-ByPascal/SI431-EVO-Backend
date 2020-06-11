using AutoMapper;
using GoingTo_API.Domain.Services.Business;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Controllers
{
    [Route ("/api/promos")]
    public class PromoController : Controller
    {
        private readonly IPromoService _promoService;
        private readonly IMapper _mapper;


    }
}
