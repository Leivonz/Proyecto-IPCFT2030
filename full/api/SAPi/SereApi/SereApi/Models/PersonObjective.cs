using System;
using System.Collections.Generic;

namespace SereApi.Models
{
    public partial class PersonObjective
    {
        public int IdPersonObjective { get; set; }
        public int? IdPerson { get; set; }
        public int? IdObjective { get; set; }

        public virtual Objective? IdObjectiveNavigation { get; set; }
        public virtual People? IdPersonNavigation { get; set; }
    }
}
