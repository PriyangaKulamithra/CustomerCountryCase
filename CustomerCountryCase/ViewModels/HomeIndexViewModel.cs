using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CustomerCountryCase.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CustomerCountryCase.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<CustomerDto> RegisteredCustomers{ get; set; }
        public IEnumerable<SelectListItem> Countries { get; set; }

        [Required(ErrorMessage = "Please add a company name")]
        [MaxLength(50)]
        public string NewCustomerName { get; set; }

        [Required(ErrorMessage = "Please select a country")]
        public int SelectedCountryId { get; set; }
    }
}
