using System.Collections.Generic;
using CustomerCountryCase.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CustomerCountryCase.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<CustomerDto> RegisteredCustomers{ get; set; }
        public IEnumerable<SelectListItem> Countries { get; set; }
    }
}
