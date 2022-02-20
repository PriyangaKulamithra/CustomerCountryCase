using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CustomerCountryCase.Data;
using CustomerCountryCase.Models;

namespace CustomerCountryCase.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerRegistrationContext _dbContext;

        public CustomerRepository(CustomerRegistrationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Customer> GetAllRegistered()
        {
            return _dbContext.Customers;
        }

        public Customer Get(string id)
        {
            var convertedId = Convert.ToInt32(id);
            return _dbContext.Customers.FirstOrDefault(c => c.Id == convertedId);
        }

        public void Add(CustomerDto customerToAdd)
        {
            var countryId = Convert.ToInt32(customerToAdd.CountryId);
            var customer = new Customer { CompanyName = customerToAdd.CompanyName, CountryId = countryId};

            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
        }

        public void Remove(string id)
        {
            var customer = Get(id);
            _dbContext.Customers.Remove(customer);
            _dbContext.SaveChanges();
        }
    }
}
