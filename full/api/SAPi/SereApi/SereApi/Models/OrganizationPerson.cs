using System;
using System.Collections.Generic;

namespace SereApi.Models
{
    public partial class OrganizationPerson
    {
        public int IdOrganizationPerson { get; set; }
        public int? IdPerson { get; set; }
        public int? IdOrganization { get; set; }

        public virtual Organization? IdOrganizationNavigation { get; set; }
        public virtual People? IdPersonNavigation { get; set; }
    }
}
