using System;
using System.Collections.Generic;

#nullable disable

namespace CustomerCountryCase.Data
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}
