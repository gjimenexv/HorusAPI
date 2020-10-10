using System;
using System.Collections.Generic;

namespace Solution.DAL.EF.Models
{
    public partial class TipoDepreciacion
    {
        public TipoDepreciacion()
        {
            Bien = new HashSet<Bien>();
        }

        public int IdTipoDepreciacion { get; set; }
        public string Descripcion { get; set; }
        public string Formula { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<Bien> Bien { get; set; }
    }
}
