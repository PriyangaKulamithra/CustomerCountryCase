using System;
using System.Collections.Generic;

#nullable disable

namespace CustomerCountryCase.Data
{
    public partial class Country
    {
        public Country()
        {
            Customers = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public string Country1 { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
