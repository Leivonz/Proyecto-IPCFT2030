using System;
using System.Collections.Generic;

namespace SereApi.Models
{
    public partial class OrganizationStatus
    {
        public OrganizationStatus()
        {
            Organizations = new HashSet<Organization>();
        }

        public int IdOrganizationStatus { get; set; }
        public string NameOrganizationStatus { get; set; }

        public virtual ICollection<Organization> Organizations { get; set; }
    }
}
