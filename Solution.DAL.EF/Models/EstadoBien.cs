using System;
using System.Collections.Generic;

namespace Solution.DAL.EF.Models
{
    public partial class EstadoBien
    {
        public EstadoBien()
        {
            Bien = new HashSet<Bien>();
            HistorialEstado = new HashSet<HistorialEstado>();
        }

        public int IdEstadoBien { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<Bien> Bien { get; set; }
        public virtual ICollection<HistorialEstado> HistorialEstado { get; set; }
    }
}
