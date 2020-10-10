using System;
using System.Collections.Generic;

namespace Solution.DAL.EF.Models
{
    public partial class HistorialPropietarios
    {
        public int IdHistorialPropietario { get; set; }
        public string Placa { get; set; }
        public string IdFuncionario { get; set; }
        public DateTime? FechaHasta { get; set; }
        public string IdFuncionarioCambia { get; set; }

        public virtual Funcionario IdFuncionarioCambiaNavigation { get; set; }
        public virtual Funcionario IdFuncionarioNavigation { get; set; }
        public virtual Bien PlacaNavigation { get; set; }
    }
}
