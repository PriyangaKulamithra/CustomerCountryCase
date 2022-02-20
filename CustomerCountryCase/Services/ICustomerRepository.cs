using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerCountryCase.Data;

namespace CustomerCountryCase.Services
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllRegistered();
        Customer Get(string id);
        void Add(string name, string countryId);
        void Remove(string id);
    }
}
