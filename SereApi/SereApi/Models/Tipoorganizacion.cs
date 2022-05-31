using System;
using System.Collections.Generic;

namespace SereApi.Models
{
    public partial class Tipoorganizacion
    {
        public Tipoorganizacion()
        {
            Organizacions = new HashSet<Organizacion>();
        }

        public int IdTipoorganizacion { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Organizacion> Organizacions { get; set; }
    }
}
