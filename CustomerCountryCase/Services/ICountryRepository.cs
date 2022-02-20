using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerCountryCase.Data;

namespace CustomerCountryCase.Services
{
    public interface ICountryRepository
    {
        IEnumerable<Country> GetAllCountries();
    }
}
