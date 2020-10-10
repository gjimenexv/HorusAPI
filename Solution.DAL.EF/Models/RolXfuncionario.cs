using System;
using System.Collections.Generic;

namespace Solution.DAL.EF.Models
{
    public partial class RolXfuncionario
    {
        public int IdRolXfuncionario { get; set; }
        public int? IdRol { get; set; }
        public string IdFuncionario { get; set; }

        public virtual Funcionario IdFuncionarioNavigation { get; set; }
        public virtual Roles IdRolNavigation { get; set; }
    }
}
