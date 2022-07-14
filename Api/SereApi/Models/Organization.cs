using System;
using System.Collections.Generic;

namespace SereApi.Models
{
    public partial class Organization
    {
        public Organization()
        {
            Events = new HashSet<Event>();
            OrganizationObjectives = new HashSet<OrganizationObjective>();
            OrganizationPeople = new HashSet<OrganizationPerson>();
            OrganizationProjects = new HashSet<OrganizationProject>();
        }

        public int IdOrganization { get; set; }
        public string NameOrganization { get; set; } = null!;
        public string DescriptionOrganization { get; set; } = null!;
        public string EmailOrganization { get; set; } = null!;
        public int Country { get; set; }
        public string Phone { get; set; } = null!;
        public int IdOrganizationType { get; set; }
        public int IdOrganizationStatus { get; set; }

        public virtual Country CountryNavigation { get; set; } = null!;
        public virtual OrganizationStatus IdOrganizationStatusNavigation { get; set; } = null!;
        public virtual OrganizationType IdOrganizationTypeNavigation { get; set; } = null!;
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<OrganizationObjective> OrganizationObjectives { get; set; }
        public virtual ICollection<OrganizationPerson> OrganizationPeople { get; set; }
        public virtual ICollection<OrganizationProject> OrganizationProjects { get; set; }
    }
}
