using System;
using System.Collections.Generic;

namespace Solution.DAL.EF.Models
{
    public partial class AccesosXrol
    {
        public int IdAccesoXrol { get; set; }
        public int IdAcceso { get; set; }
        public int IdRol { get; set; }

        public virtual Acceso IdAccesoNavigation { get; set; }
        public virtual Roles IdRolNavigation { get; set; }
    }
}
