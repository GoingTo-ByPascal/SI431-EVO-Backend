using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Repositories;
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
        private readonly IUnitOfWork _unitOfWork;
        public CountryService(ICountryRepository countryRepository,IUnitOfWork unitOfWork)
        {
            _countryRepository = countryRepository;
            _unitOfWork = unitOfWork;
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
    }
}
