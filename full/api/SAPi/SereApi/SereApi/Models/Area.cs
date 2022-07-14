using System;
using System.Collections.Generic;

namespace SereApi.Models
{
    public partial class Area
    {
        public Area()
        {
            Projects = new HashSet<Project>();
        }

        public int IdArea { get; set; }
        public string NameArea { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
