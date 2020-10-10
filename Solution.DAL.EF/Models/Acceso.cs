using System;
using System.Collections.Generic;

namespace Solution.DAL.EF.Models
{
    public partial class Acceso
    {
        public Acceso()
        {
            AccesosXrol = new HashSet<AccesosXrol>();
        }

        public int IdAcceso { get; set; }
        public string Descripcion { get; set; }
        public string Url { get; set; }

        public virtual ICollection<AccesosXrol> AccesosXrol { get; set; }
    }
}
