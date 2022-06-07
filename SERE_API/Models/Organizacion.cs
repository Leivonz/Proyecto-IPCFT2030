using System;
using System.Collections.Generic;

namespace SERE_API.Models
{
    public partial class Organizacion
    {
        public Organizacion()
        {
            Eventos = new HashSet<Evento>();
            OrganizacionOds = new HashSet<OrganizacionOd>();
            OrganizacionPersonas = new HashSet<OrganizacionPersona>();
            OrganizacionProyectos = new HashSet<OrganizacionProyecto>();
        }

        public int IdOrganizacion { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? CorreoOrganizacion { get; set; }
        public int? Pais { get; set; }
        public string? Telefono { get; set; }
        public int? IdTipoorganizacion { get; set; }
        public int? IdEstadoorganizacion { get; set; }

        public virtual Estadoorganizacion? IdEstadoorganizacionNavigation { get; set; }
        public virtual Tipoorganizacion? IdTipoorganizacionNavigation { get; set; }
        public virtual Pai? PaisNavigation { get; set; }
        public virtual ICollection<Evento> Eventos { get; set; }
        public virtual ICollection<OrganizacionOd> OrganizacionOds { get; set; }
        public virtual ICollection<OrganizacionPersona> OrganizacionPersonas { get; set; }
        public virtual ICollection<OrganizacionProyecto> OrganizacionProyectos { get; set; }
    }
}
