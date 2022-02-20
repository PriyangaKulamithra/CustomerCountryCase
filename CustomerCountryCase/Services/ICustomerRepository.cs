using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerCountryCase.Data;
using CustomerCountryCase.Models;

namespace CustomerCountryCase.Services
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllRegistered();
        Customer Get(string id);
        void Add(NewCustomerDto customer);
        void Remove(string id);
    }
}
