using System;
using System.Collections.Generic;

namespace SERE_API.Models
{
    public partial class Estadoorganizacion
    {
        public Estadoorganizacion()
        {
            Organizacions = new HashSet<Organizacion>();
        }

        public int IdEstadoorganizacion { get; set; }
        public string? NombreEstado { get; set; }

        public virtual ICollection<Organizacion> Organizacions { get; set; }
    }
}
