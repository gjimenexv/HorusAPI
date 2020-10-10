using System;
using System.Collections.Generic;

namespace Solution.DAL.EF.Models
{
    public partial class Bien
    {
        public Bien()
        {
            BienesIdentificados = new HashSet<BienesIdentificados>();
            HistorialEstado = new HashSet<HistorialEstado>();
            HistorialPropietarios = new HashSet<HistorialPropietarios>();
        }

        public string Placa { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public decimal? ValorInicial { get; set; }
        public int? Garantia { get; set; }
        public string Observaciones { get; set; }
        public bool? EntregadoBienes { get; set; }
        public int? IdTipoDepreciacion { get; set; }
        public int? IdCentroCosto { get; set; }
        public int? IdEstadoBien { get; set; }
        public string IdFuncionario { get; set; }
        public int? IdTipoBien { get; set; }

        public virtual CentroCosto IdCentroCostoNavigation { get; set; }
        public virtual EstadoBien IdEstadoBienNavigation { get; set; }
        public virtual Funcionario IdFuncionarioNavigation { get; set; }
        public virtual TipoBien IdTipoBienNavigation { get; set; }
        public virtual TipoDepreciacion IdTipoDepreciacionNavigation { get; set; }
        public virtual ICollection<BienesIdentificados> BienesIdentificados { get; set; }
        public virtual ICollection<HistorialEstado> HistorialEstado { get; set; }
        public virtual ICollection<HistorialPropietarios> HistorialPropietarios { get; set; }
    }
}
