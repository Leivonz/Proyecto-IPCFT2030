using System;
using System.Collections.Generic;

namespace SereApi.Models
{
    public partial class ProjectObjective
    {
        public int IdProjectObjective { get; set; }
        public int IdProject { get; set; }
        public int IdObjective { get; set; }

        public virtual Objective? IdObjectiveNavigation { get; set; }
        public virtual Project? IdProjectNavigation { get; set; }
    }
}
