using System;
using System.Collections.Generic;

namespace SereApi.Models
{
    public partial class PersonaProyecto
    {
        public int IdOrganizacionProyecto { get; set; }
        public int? IdPersona { get; set; }
        public int? IdProyecto { get; set; }

        public virtual Persona? IdPersonaNavigation { get; set; }
        public virtual Proyecto? IdProyectoNavigation { get; set; }
    }
}
