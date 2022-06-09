using System;
using System.Collections.Generic;

namespace SereApi.Models
{
    public partial class Objective
    {
        public Objective()
        {
            Events = new HashSet<Event>();
            OrganizationObjectives = new HashSet<OrganizationObjective>();
            PersonObjectives = new HashSet<PersonObjective>();
            ProjectObjectives = new HashSet<ProjectObjective>();
        }

        public int IdObjective { get; set; }
        public string? NameObjective { get; set; }
        public string? IndicadorObjective { get; set; }
        public string? MetasObjective { get; set; }
        public string? ObjectiveObjective { get; set; }

        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<OrganizationObjective> OrganizationObjectives { get; set; }
        public virtual ICollection<PersonObjective> PersonObjectives { get; set; }
        public virtual ICollection<ProjectObjective> ProjectObjectives { get; set; }
    }
}
