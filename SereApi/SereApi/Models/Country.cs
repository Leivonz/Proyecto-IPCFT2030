using System;
using System.Collections.Generic;

namespace SereApi.Models
{
    public partial class Country
    {
        public Country()
        {
            Organizations = new HashSet<Organization>();
        }

        public int IdCountry { get; set; }
        public string? NameCountry { get; set; }

        public virtual ICollection<Organization> Organizations { get; set; }
    }
}
