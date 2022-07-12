using System;
using System.Collections.Generic;

namespace SereApi.Models
{
    public partial class OrganizationProject
    {
        public int IdOrganizationProject { get; set; }
        public int IdOrganization { get; set; }
        public int IdProject { get; set; }

        public virtual Organization? IdOrganizationNavigation { get; set; }
        public virtual Project? IdProjectNavigation { get; set; }
    }
}
