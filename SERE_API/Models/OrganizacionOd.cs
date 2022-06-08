using System;
using System.Collections.Generic;

namespace SereApi.Models
{
    public partial class OrganizacionOd
    {
        public int IpOrganizacionOds { get; set; }
        public int? IdOrganizacion { get; set; }
        public int? IdOds { get; set; }

        public virtual Od? IdOdsNavigation { get; set; }
        public virtual Organizacion? IdOrganizacionNavigation { get; set; }
    }
}
