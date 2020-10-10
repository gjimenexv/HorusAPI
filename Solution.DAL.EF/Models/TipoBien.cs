using System;
using System.Collections.Generic;

namespace Solution.DAL.EF.Models
{
    public partial class TipoBien
    {
        public TipoBien()
        {
            Bien = new HashSet<Bien>();
        }

        public int IdTipoBien { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<Bien> Bien { get; set; }
    }
}
