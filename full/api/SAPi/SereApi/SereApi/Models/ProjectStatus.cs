using System;
using System.Collections.Generic;

namespace SereApi.Models
{
    public partial class ProjectStatus
    {
        public ProjectStatus()
        {
            Projects = new HashSet<Project>();
        }

        public int IdProjectStatus { get; set; }
        public string NameProjectStatus { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
