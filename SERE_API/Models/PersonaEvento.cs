using System;
using System.Collections.Generic;

namespace SereApi.Models
{
    public partial class PersonaEvento
    {
        public int? IdEvento { get; set; }
        public int? IdPersona { get; set; }

        public virtual Evento? IdEventoNavigation { get; set; }
        public virtual Persona? IdPersonaNavigation { get; set; }
    }
}
