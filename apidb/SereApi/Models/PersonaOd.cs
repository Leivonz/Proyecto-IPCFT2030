using System;
using System.Collections.Generic;

namespace SereApi.Models
{
    public partial class PersonaOd
    {
        public int IdPersonaOds { get; set; }
        public int? IdPersona { get; set; }
        public int? IdOds { get; set; }

        public virtual Od? IdOdsNavigation { get; set; }
        public virtual Persona? IdPersonaNavigation { get; set; }
    }
}
