using System;
using System.Collections.Generic;

namespace Solution.DAL.EF.Models
{
    public partial class Oficina
    {
        public Oficina()
        {
            Funcionario = new HashSet<Funcionario>();
        }

        public int IdOficina { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<Funcionario> Funcionario { get; set; }
    }
}
