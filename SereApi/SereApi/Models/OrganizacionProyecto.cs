using System;
using System.Collections.Generic;

namespace SereApi.Models
{
    public partial class OrganizacionProyecto
    {
        public int IdOrganizacionProyecto { get; set; }
        public int? IdOrganizacion { get; set; }
        public int? IdProyecto { get; set; }

        public virtual Organizacion? IdOrganizacionNavigation { get; set; }
        public virtual Proyecto? IdProyectoNavigation { get; set; }
    }
}
