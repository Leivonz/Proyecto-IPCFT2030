using System;
using System.Collections.Generic;

namespace SereApi.Models
{
    public partial class OrganizacionPersona
    {
        public int IdOrganizacionPersona { get; set; }
        public int? IdPersona { get; set; }
        public int? IdOrganizacion { get; set; }

        public virtual Organizacion? IdOrganizacionNavigation { get; set; }
        public virtual Persona? IdPersonaNavigation { get; set; }
    }
}
