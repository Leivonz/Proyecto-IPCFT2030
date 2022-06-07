using System;
using System.Collections.Generic;

namespace SERE_API.Models
{
    public partial class Persona
    {
        public Persona()
        {
            OrganizacionPersonas = new HashSet<OrganizacionPersona>();
            PersonaOds = new HashSet<PersonaOd>();
            PersonaProyectos = new HashSet<PersonaProyecto>();
            Proyectos = new HashSet<Proyecto>();
        }

        public int IdPersona { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Email { get; set; }
        public string? Fono { get; set; }

        public virtual ICollection<OrganizacionPersona> OrganizacionPersonas { get; set; }
        public virtual ICollection<PersonaOd> PersonaOds { get; set; }
        public virtual ICollection<PersonaProyecto> PersonaProyectos { get; set; }
        public virtual ICollection<Proyecto> Proyectos { get; set; }
    }
}
