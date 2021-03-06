using System;
using System.Collections.Generic;

namespace SereApi.Models
{
    public partial class Area
    {
        public Area()
        {
            Proyectos = new HashSet<Proyecto>();
        }

        public int IdArea { get; set; }
        public string? NombreArea { get; set; }

        public virtual ICollection<Proyecto> Proyectos { get; set; }
    }
}
