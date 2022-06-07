using System;
using System.Collections.Generic;

namespace SERE_API.Models
{
    public partial class Pai
    {
        public Pai()
        {
            Organizacions = new HashSet<Organizacion>();
        }

        public int IdPais { get; set; }
        public string? NombrePais { get; set; }

        public virtual ICollection<Organizacion> Organizacions { get; set; }
    }
}
