using System;
using System.Collections.Generic;

namespace SERE_API.Models
{
    public partial class Od
    {
        public Od()
        {
            Eventos = new HashSet<Evento>();
            OrganizacionOds = new HashSet<OrganizacionOd>();
            PersonaOds = new HashSet<PersonaOd>();
            ProyectoOds = new HashSet<ProyectoOd>();
        }

        public int IdOds { get; set; }
        public string? NombreOds { get; set; }
        public string? Indicador { get; set; }
        public string? MetasOds { get; set; }
        public string? ObjetivosOds { get; set; }

        public virtual ICollection<Evento> Eventos { get; set; }
        public virtual ICollection<OrganizacionOd> OrganizacionOds { get; set; }
        public virtual ICollection<PersonaOd> PersonaOds { get; set; }
        public virtual ICollection<ProyectoOd> ProyectoOds { get; set; }
    }
}
