using System;
using System.Collections.Generic;

namespace SERE_API.Models
{
    public partial class Proyecto
    {
        public Proyecto()
        {
            OrganizacionProyectos = new HashSet<OrganizacionProyecto>();
            PersonaProyectos = new HashSet<PersonaProyecto>();
            ProyectoOds = new HashSet<ProyectoOd>();
        }

        public int IdProyecto { get; set; }
        public int? Monto { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaInico { get; set; }
        public DateTime? FechaTermino { get; set; }
        public int? Meses { get; set; }
        public string? Descripcion { get; set; }
        public string? PalabrasClave { get; set; }
        public string? Objetivos { get; set; }
        public int? IdArea { get; set; }
        public int? IdEstadoproyecto { get; set; }
        public int? IdOds { get; set; }
        public int? IdPersonaresponsable { get; set; }

        public virtual Area? IdAreaNavigation { get; set; }
        public virtual Estadoproyecto? IdEstadoproyectoNavigation { get; set; }
        public virtual Persona? IdPersonaresponsableNavigation { get; set; }
        public virtual ICollection<OrganizacionProyecto> OrganizacionProyectos { get; set; }
        public virtual ICollection<PersonaProyecto> PersonaProyectos { get; set; }
        public virtual ICollection<ProyectoOd> ProyectoOds { get; set; }
    }
}
