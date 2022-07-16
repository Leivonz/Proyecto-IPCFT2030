using System;
using System.Collections.Generic;

namespace SereApi.Models
{
    public partial class Person
    {
        public Person()
        {
            OrganizationPeople = new HashSet<OrganizationPerson>();
            PersonEvents = new HashSet<PersonEvent>();
            PersonObjectives = new HashSet<PersonObjective>();
            PersonProjects = new HashSet<PersonProject>();
            Projects = new HashSet<Project>();
            WebProjectPeople = new HashSet<WebProjectPerson>();
        }

        public int IdPerson { get; set; }
        public string NamePerson { get; set; } = null!;
        public string SurnamePerson { get; set; } = null!;
        public string EmailPerson { get; set; } = String.Empty;
        public string PhonePerson { get; set; } = null!;
        public string PasswordPerson { get; set; } = null!;
        public string OrganizationName { get; set; } = null!;
        public int CountryPerson { get; set; }

        public virtual Country CountryPersonNavigation { get; set; } = null!;
        public virtual ICollection<OrganizationPerson> OrganizationPeople { get; set; }
        public virtual ICollection<PersonEvent> PersonEvents { get; set; }
        public virtual ICollection<PersonObjective> PersonObjectives { get; set; }
        public virtual ICollection<PersonProject> PersonProjects { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<WebProjectPerson> WebProjectPeople { get; set; }
    }
}
