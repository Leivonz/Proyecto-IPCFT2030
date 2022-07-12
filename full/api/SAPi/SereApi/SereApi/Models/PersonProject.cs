using System;
using System.Collections.Generic;

namespace SereApi.Models
{
    public partial class PersonProject
    {
        public int IdPersonProject { get; set; }
        public int? IdPerson { get; set; }
        public int? IdProject { get; set; }

        public virtual People? IdPersonNavigation { get; set; }
        public virtual Project? IdProjectNavigation { get; set; }
    }
}
