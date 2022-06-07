using System;
using System.Collections.Generic;

namespace SERE_API.Models
{
    public partial class Evento
    {
        public int IdEvento { get; set; }
        public string NombreEvento { get; set; } = null!;
        public DateTime FechaEvento { get; set; }
        public string DescEvento { get; set; } = null!;
        public int OdsEvento { get; set; }
        public int? IdTipoEvento { get; set; }
        public int? CantCupos { get; set; }
        public decimal CostoEvento { get; set; }
        public int IdOrganizacion { get; set; }

        public virtual Organizacion IdOrganizacionNavigation { get; set; } = null!;
        public virtual TipoEvento? IdTipoEventoNavigation { get; set; }
        public virtual Od OdsEventoNavigation { get; set; } = null!;
    }
}
