using System;
using System.Collections.Generic;

namespace Solution.DAL.EF.Models
{
    public partial class TomaInventario
    {
        public int IdTomaInventario { get; set; }
        public string IdFuncionario { get; set; }
        public int? IdCentroCosto { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public bool? Estado { get; set; }

        public virtual CentroCosto IdCentroCostoNavigation { get; set; }
        public virtual Funcionario IdFuncionarioNavigation { get; set; }
        public virtual BienesIdentificados IdTomaInventarioNavigation { get; set; }
    }
}
