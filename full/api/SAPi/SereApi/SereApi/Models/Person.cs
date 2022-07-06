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
        }

        public int IdPerson { get; set; }
        public string? NamePerson { get; set; }
        public string? SurnamePerson { get; set; }
        public string? EmailPerson { get; set; }
        public string? PhonePerson { get; set; }
        public string? PasswordPerson { get; set; }

        public virtual ICollection<OrganizationPerson> OrganizationPeople { get; set; }
        public virtual ICollection<PersonEvent> PersonEvents { get; set; }
        public virtual ICollection<PersonObjective> PersonObjectives { get; set; }
        public virtual ICollection<PersonProject> PersonProjects { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
