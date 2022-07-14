using System;
using System.Collections.Generic;

namespace SereApi.Models
{
    public partial class Country
    {
        public Country()
        {
            Organizations = new HashSet<Organization>();
            People = new HashSet<Person>();
        }

        public int IdCountry { get; set; }
        public string NameCountry { get; set; } = null!;

        public virtual ICollection<Organization> Organizations { get; set; }
        public virtual ICollection<Person> People { get; set; }
    }
}
