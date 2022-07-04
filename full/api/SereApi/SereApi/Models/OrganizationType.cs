using System;
using System.Collections.Generic;

namespace SereApi.Models
{
    public partial class OrganizationType
    {
        public OrganizationType()
        {
            Organizations = new HashSet<Organization>();
        }

        public int IdOrganizationType { get; set; }
        public string? NameOrganizationType { get; set; }

        public virtual ICollection<Organization> Organizations { get; set; }
    }
}
