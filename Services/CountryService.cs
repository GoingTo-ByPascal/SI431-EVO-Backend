using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Repositories;
using GoingTo_API.Domain.Repositories.Geographic;
using GoingTo_API.Domain.Services;
using GoingTo_API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly ICountryCurrencyRepository _countryCurrencyRepository;
        
        public CountryService(ICountryRepository countryRepository, ICountryCurrencyRepository countryCurrencyRepository)
        {
            _countryRepository = countryRepository;
            _countryCurrencyRepository = countryCurrencyRepository;
        }
        public async Task<CountryResponse> GetByIdAsync(int id)
        {
            var existingCountry = await _countryRepository.FindById(id);

            if (existingCountry == null)
                return new CountryResponse("Country id not found");
            return new CountryResponse(existingCountry);
        }

        public async Task<CountryResponse> GetByFullNameAsync(string fullname)
        {
            var existingCountry = await _countryRepository.FindByFullName(fullname);

            if (existingCountry == null)
                return new CountryResponse("Country name not found");
            return new CountryResponse(existingCountry);
        }

        public async Task<IEnumerable<Country>> ListAsync()
        {
            return await _countryRepository.ListAsync();
        }

        public async Task<IEnumerable<Country>> ListByCurrencyIdAsync(int currencyId)
        {
            var countryCurrencies = await _countryCurrencyRepository.ListByCurrencyAsync(currencyId);
            var countries = countryCurrencies.Select(cc => cc.Country).ToList();
            return countries;

        }
    }
}
