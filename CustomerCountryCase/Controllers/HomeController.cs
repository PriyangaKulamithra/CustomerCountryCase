using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CustomerCountryCase.Data;
using CustomerCountryCase.Models;
using CustomerCountryCase.Services;
using CustomerCountryCase.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CustomerCountryCase.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICountryRepository _countryRepository;

        public HomeController(
            ILogger<HomeController> logger,
            ICustomerRepository customerRepository, 
            ICountryRepository countryRepository)
        {
            _logger = logger;
            _customerRepository = customerRepository;
            _countryRepository = countryRepository;
        }

        public IActionResult Index()
        {
            var viewmodel = new HomeIndexViewModel
            {
                RegisteredCustomers = GetAllCustomers(),
                Countries = GetCountrySelectListItems()
            };
            return View(viewmodel);
        }

        [HttpPost]
        public IActionResult Index(HomeIndexViewModel model)
        {
            if(model.SelectedCountryId == 0)
                ModelState.AddModelError("SelectedCountryId", "Please select a country");

            if (ModelState.IsValid)
            {
                var newCustomer = new NewCustomerDto { CompanyName = model.NewCustomerName, CountryId = model.SelectedCountryId.ToString() };
                _customerRepository.Add(newCustomer);
                return RedirectToAction("Index");
            }

            model.RegisteredCustomers = GetAllCustomers();
            model.Countries = GetCountrySelectListItems();
            return View(model);
        }

        private IEnumerable<CustomerDto> GetAllCustomers()
        {
            return _customerRepository.GetAllRegistered().Select(c => new CustomerDto
            {
                CompanyName = c.CompanyName, 
                Country = c.Country.Country1
            });
        }

        private IEnumerable<SelectListItem> GetCountrySelectListItems()
        {
            var list = _countryRepository.GetAllCountries()
                .Select(country => new SelectListItem {Text = country.Country1, Value = country.Id.ToString()}).ToList();

            list.Add(new SelectListItem{ Text = "Choose country", Value = "0", Disabled = true});

            return list;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
