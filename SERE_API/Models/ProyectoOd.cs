using System;
using System.Collections.Generic;

namespace SERE_API.Models
{
    public partial class ProyectoOd
    {
        public int IdProyectoOds { get; set; }
        public int? IdProyecto { get; set; }
        public int? IdOds { get; set; }

        public virtual Od? IdOdsNavigation { get; set; }
        public virtual Proyecto? IdProyectoNavigation { get; set; }
    }
}
