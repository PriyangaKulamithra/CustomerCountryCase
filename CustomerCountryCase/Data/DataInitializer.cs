using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CustomerCountryCase.Data
{
    public class DataInitializer
    {
        public static void SeedData(CustomerRegistrationContext dbContext)
        {
            dbContext.Database.Migrate();
            SeedCountries(dbContext);
            SeedCustomers(dbContext);
        }

        private static void SeedCustomers(CustomerRegistrationContext dbContext)
        {
            AddCustomerIfNotExists("Lakeforce AB", dbContext);
        }

        private static void AddCustomerIfNotExists(string companyName, CustomerRegistrationContext dbContext)
        {
            var customer = dbContext.Customers.FirstOrDefault(c => c.CompanyName == companyName);
            if (customer == null)
                dbContext.Customers.Add(new Customer
                {
                    CompanyName = companyName, 
                    CountryId = dbContext.Countries.First().Id
                });

            dbContext.SaveChanges();
        }

        private static void SeedCountries(CustomerRegistrationContext dbContext)
        {
            AddCountryIfNotExists("Sweden", dbContext);
            AddCountryIfNotExists("Finland", dbContext);
            AddCountryIfNotExists("Denmark", dbContext);
            AddCountryIfNotExists("Germany", dbContext);
        }

        private static void AddCountryIfNotExists(string countryName, CustomerRegistrationContext dbContext)
        {
            var country = dbContext.Countries.FirstOrDefault(c => c.Country1 == countryName);
            if (country == null)
                dbContext.Countries.Add(new Country { Country1 = countryName});

            dbContext.SaveChanges();
        }
    }
}
