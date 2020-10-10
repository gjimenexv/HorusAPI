using System;
using System.Collections.Generic;

namespace Solution.DAL.EF.Models
{
    public partial class CentroCosto
    {
        public CentroCosto()
        {
            Bien = new HashSet<Bien>();
            TomaInventario = new HashSet<TomaInventario>();
        }

        public int IdCentroCosto { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<Bien> Bien { get; set; }
        public virtual ICollection<TomaInventario> TomaInventario { get; set; }
    }
}
