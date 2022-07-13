using System;
using System.Collections.Generic;

namespace SereApi.Models
{
    public partial class OrganizationObjective
    {
        public int IdOrganizationObjective { get; set; }
        public int IdOrganization { get; set; }
        public int IdObjective { get; set; }

        public virtual Objective? IdObjectiveNavigation { get; set; }
        public virtual Organization? IdOrganizationNavigation { get; set; }
    }
}
