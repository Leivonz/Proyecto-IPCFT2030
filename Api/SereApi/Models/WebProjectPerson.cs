using System;
using System.Collections.Generic;

namespace SereApi.Models
{
    public partial class WebProjectPerson
    {
        public int IdWebProjectPerson { get; set; }
        public int? IdPerson { get; set; }
        public int? IdWebProject { get; set; }

        public virtual Person? IdPersonNavigation { get; set; }
        public virtual WebProject? IdWebProjectNavigation { get; set; }
    }
}
