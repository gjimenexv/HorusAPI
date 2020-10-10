using System;
using System.Collections.Generic;

namespace Solution.DAL.EF.Models
{
    public partial class Roles
    {
        public Roles()
        {
            AccesosXrol = new HashSet<AccesosXrol>();
            RolXfuncionario = new HashSet<RolXfuncionario>();
        }

        public int IdRol { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<AccesosXrol> AccesosXrol { get; set; }
        public virtual ICollection<RolXfuncionario> RolXfuncionario { get; set; }
    }
}
