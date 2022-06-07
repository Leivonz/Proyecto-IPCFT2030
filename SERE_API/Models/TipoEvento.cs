﻿using System;
using System.Collections.Generic;

namespace SERE_API.Models
{
    public partial class TipoEvento
    {
        public TipoEvento()
        {
            Eventos = new HashSet<Evento>();
        }

        public int IdEvento { get; set; }
        public string NombreTipo { get; set; } = null!;

        public virtual ICollection<Evento> Eventos { get; set; }
    }
}
