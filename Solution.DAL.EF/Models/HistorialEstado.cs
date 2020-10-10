using System;
using System.Collections.Generic;

namespace Solution.DAL.EF.Models
{
    public partial class HistorialEstado
    {
        public int IdHistorialEstado { get; set; }
        public string Placa { get; set; }
        public string IdFuncionario { get; set; }
        public DateTime? FechaHasta { get; set; }
        public int? IdEstadoBien { get; set; }

        public virtual EstadoBien IdEstadoBienNavigation { get; set; }
        public virtual Funcionario IdFuncionarioNavigation { get; set; }
        public virtual Bien PlacaNavigation { get; set; }
    }
}
