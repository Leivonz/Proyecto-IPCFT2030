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
        public string NameOrganization { get; set; }
        public string DescriptionOrganization { get; set; }
        public string EmailOrganization { get; set; }
        public int Country { get; set; }
        public string Phone { get; set; }
        public int IdOrganizationType { get; set; }
        public int IdOrganizationStatus { get; set; }

        public virtual Country? CountryNavigation { get; set; }
        public virtual OrganizationStatus? IdOrganizationStatusNavigation { get; set; }
        public virtual OrganizationType? IdOrganizationTypeNavigation { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<OrganizationObjective> OrganizationObjectives { get; set; }
        public virtual ICollection<OrganizationPerson> OrganizationPeople { get; set; }
        public virtual ICollection<OrganizationProject> OrganizationProjects { get; set; }
    }
}
