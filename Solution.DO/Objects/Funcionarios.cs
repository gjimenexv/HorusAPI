using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Solution.DO.Objects
{
    public class Funcionarios
    {

        //[IdFuncionario][varchar](50) NOT NULL,
        //[IdOficina] [int] NOT NULL,
        //[NombreCompleto] [varchar] (250) NULL,
        //[Usuario] [varchar] (30) NULL,
        //[Contrasena] [varchar] (30) NULL,
        //[CorreoElectronico] [varchar] (150) NULL,
        //CONSTRAINT[PK_Funcionario] PRIMARY KEY CLUSTERED

        [Key]
        public int IdFuncionario { get; set; }
        public int IdOficina { get; set; }
        public string NombrCompleto { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public string CorreoElectronico { get; set; }
    }
}
