using System;
using System.Collections.Generic;

namespace SereApi.Models
{
    public partial class PersonEvent
    {
        public int IdPersonEvent { get; set; }
        public int IdEvent { get; set; }
        public int IdPerson { get; set; }

        public virtual Event IdEventNavigation { get; set; } = null!;
        public virtual Person IdPersonNavigation { get; set; } = null!;
    }
}
