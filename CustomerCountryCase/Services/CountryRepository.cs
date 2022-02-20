using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerCountryCase.Data;

namespace CustomerCountryCase.Services
{
    public class CountryRepository : ICountryRepository
    {
        private readonly CustomerRegistrationContext _dbContext;

        public CountryRepository(CustomerRegistrationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Country> GetAllCountries()
        {
            return _dbContext.Countries;
        }
    }
}
