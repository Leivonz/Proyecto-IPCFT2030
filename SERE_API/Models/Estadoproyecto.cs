using System;
using System.Collections.Generic;

namespace SERE_API.Models
{
    public partial class Estadoproyecto
    {
        public Estadoproyecto()
        {
            Proyectos = new HashSet<Proyecto>();
        }

        public int IdEstadoproyecto { get; set; }
        public string? NombreEstadoproyecto { get; set; }

        public virtual ICollection<Proyecto> Proyectos { get; set; }
    }
}
