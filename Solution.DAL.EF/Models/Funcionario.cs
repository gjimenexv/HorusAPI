using System;
using System.Collections.Generic;

namespace Solution.DAL.EF.Models
{
    public partial class Funcionario
    {
        public Funcionario()
        {
            Bien = new HashSet<Bien>();
            HistorialEstado = new HashSet<HistorialEstado>();
            HistorialPropietariosIdFuncionarioCambiaNavigation = new HashSet<HistorialPropietarios>();
            HistorialPropietariosIdFuncionarioNavigation = new HashSet<HistorialPropietarios>();
            RolXfuncionario = new HashSet<RolXfuncionario>();
            TomaInventario = new HashSet<TomaInventario>();
        }

        public string IdFuncionario { get; set; }
        public int IdOficina { get; set; }
        public string NombreCompleto { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public string CorreoElectronico { get; set; }

        public virtual Oficina IdOficinaNavigation { get; set; }
        public virtual ICollection<Bien> Bien { get; set; }
        public virtual ICollection<HistorialEstado> HistorialEstado { get; set; }
        public virtual ICollection<HistorialPropietarios> HistorialPropietariosIdFuncionarioCambiaNavigation { get; set; }
        public virtual ICollection<HistorialPropietarios> HistorialPropietariosIdFuncionarioNavigation { get; set; }
        public virtual ICollection<RolXfuncionario> RolXfuncionario { get; set; }
        public virtual ICollection<TomaInventario> TomaInventario { get; set; }
    }
}
