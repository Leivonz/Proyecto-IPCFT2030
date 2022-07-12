using System;
using System.Collections.Generic;

namespace SereApi.Models
{
    public partial class Project
    {
        public Project()
        {
            OrganizationProjects = new HashSet<OrganizationProject>();
            PersonProjects = new HashSet<PersonProject>();
            ProjectObjectives = new HashSet<ProjectObjective>();
        }

        public int IdProject { get; set; }
        public int? MontoProject { get; set; }
        public DateTime? CreationDateProject { get; set; }
        public DateTime? StartDateProject { get; set; }
        public DateTime? EndDateProject { get; set; }
        public int? MonthsProject { get; set; }
        public string? DescriptionProject { get; set; }
        public string? KeyWordsProject { get; set; }
        public string? ObjectivesProject { get; set; }
        public int? IdArea { get; set; }
        public int? IdProjectStatus { get; set; }
        public int? IdObjectiveObjective { get; set; }
        public int? IdPersonResponsable { get; set; }

        public virtual Area? IdAreaNavigation { get; set; }
        public virtual People? IdPersonResponsableNavigation { get; set; }
        public virtual ProjectStatus? IdProjectStatusNavigation { get; set; }
        public virtual ICollection<OrganizationProject> OrganizationProjects { get; set; }
        public virtual ICollection<PersonProject> PersonProjects { get; set; }
        public virtual ICollection<ProjectObjective> ProjectObjectives { get; set; }
    }
}
