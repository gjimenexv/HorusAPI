using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Solution.DAL.EF.Models
{
    public partial class ProyectoHorusContext : DbContext
    {
        public ProyectoHorusContext()
        {
        }

        public ProyectoHorusContext(DbContextOptions<ProyectoHorusContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Acceso> Acceso { get; set; }
        public virtual DbSet<AccesosXrol> AccesosXrol { get; set; }
        public virtual DbSet<Bien> Bien { get; set; }
        public virtual DbSet<BienesIdentificados> BienesIdentificados { get; set; }
        public virtual DbSet<Bitacora> Bitacora { get; set; }
        public virtual DbSet<CentroCosto> CentroCosto { get; set; }
        public virtual DbSet<EstadoBien> EstadoBien { get; set; }
        public virtual DbSet<Funcionario> Funcionario { get; set; }
        public virtual DbSet<HistorialEstado> HistorialEstado { get; set; }
        public virtual DbSet<HistorialPropietarios> HistorialPropietarios { get; set; }
        public virtual DbSet<Oficina> Oficina { get; set; }
        public virtual DbSet<RolXfuncionario> RolXfuncionario { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<TipoBien> TipoBien { get; set; }
        public virtual DbSet<TipoDepreciacion> TipoDepreciacion { get; set; }
        public virtual DbSet<TomaInventario> TomaInventario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=GUILLERMO;Database=ProyectoHorus;User Id=guillesa;Password=oracle;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Acceso>(entity =>
            {
                entity.HasKey(e => e.IdAcceso);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AccesosXrol>(entity =>
            {
                entity.HasKey(e => e.IdAccesoXrol);

                entity.ToTable("AccesosXRol");

                entity.Property(e => e.IdAccesoXrol).HasColumnName("IdAccesoXRol");

                entity.HasOne(d => d.IdAccesoNavigation)
                    .WithMany(p => p.AccesosXrol)
                    .HasForeignKey(d => d.IdAcceso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccesosXRol_Acceso");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.AccesosXrol)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccesosXRol_Roles");
            });

            modelBuilder.Entity<Bien>(entity =>
            {
                entity.HasKey(e => e.Placa);

                entity.Property(e => e.Placa)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaIngreso).HasColumnType("datetime");

                entity.Property(e => e.IdFuncionario)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ValorInicial).HasColumnType("money");

                entity.HasOne(d => d.IdCentroCostoNavigation)
                    .WithMany(p => p.Bien)
                    .HasForeignKey(d => d.IdCentroCosto)
                    .HasConstraintName("FK_Bien_CentroCosto");

                entity.HasOne(d => d.IdEstadoBienNavigation)
                    .WithMany(p => p.Bien)
                    .HasForeignKey(d => d.IdEstadoBien)
                    .HasConstraintName("FK_Bien_EstadoBien");

                entity.HasOne(d => d.IdFuncionarioNavigation)
                    .WithMany(p => p.Bien)
                    .HasForeignKey(d => d.IdFuncionario)
                    .HasConstraintName("FK_Bien_Funcionario");

                entity.HasOne(d => d.IdTipoBienNavigation)
                    .WithMany(p => p.Bien)
                    .HasForeignKey(d => d.IdTipoBien)
                    .HasConstraintName("FK_Bien_TipoBien");

                entity.HasOne(d => d.IdTipoDepreciacionNavigation)
                    .WithMany(p => p.Bien)
                    .HasForeignKey(d => d.IdTipoDepreciacion)
                    .HasConstraintName("FK_Bien_TipoDepreciacion");
            });

            modelBuilder.Entity<BienesIdentificados>(entity =>
            {
                entity.HasKey(e => e.IdBienIdentificado);

                entity.Property(e => e.IdBienIdentificado).ValueGeneratedNever();

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Placa)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.PlacaNavigation)
                    .WithMany(p => p.BienesIdentificados)
                    .HasForeignKey(d => d.Placa)
                    .HasConstraintName("FK_BienesIdentificados_Bien");
            });

            modelBuilder.Entity<Bitacora>(entity =>
            {
                entity.HasKey(e => e.IdBitacora);

                entity.Property(e => e.Accion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Controlador)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Error).IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("datetime");
            });

            modelBuilder.Entity<CentroCosto>(entity =>
            {
                entity.HasKey(e => e.IdCentroCosto);

                entity.Property(e => e.IdCentroCosto).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EstadoBien>(entity =>
            {
                entity.HasKey(e => e.IdEstadoBien);

                entity.Property(e => e.IdEstadoBien).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.HasKey(e => e.IdFuncionario);

                entity.Property(e => e.IdFuncionario)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NombreCompleto)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdOficinaNavigation)
                    .WithMany(p => p.Funcionario)
                    .HasForeignKey(d => d.IdOficina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Funcionario_Oficina");
            });

            modelBuilder.Entity<HistorialEstado>(entity =>
            {
                entity.HasKey(e => e.IdHistorialEstado);

                entity.Property(e => e.IdHistorialEstado).ValueGeneratedNever();

                entity.Property(e => e.FechaHasta).HasColumnType("datetime");

                entity.Property(e => e.IdFuncionario)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Placa)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEstadoBienNavigation)
                    .WithMany(p => p.HistorialEstado)
                    .HasForeignKey(d => d.IdEstadoBien)
                    .HasConstraintName("FK_HistorialEstado_EstadoBien");

                entity.HasOne(d => d.IdFuncionarioNavigation)
                    .WithMany(p => p.HistorialEstado)
                    .HasForeignKey(d => d.IdFuncionario)
                    .HasConstraintName("FK_HistorialEstado_Funcionario");

                entity.HasOne(d => d.PlacaNavigation)
                    .WithMany(p => p.HistorialEstado)
                    .HasForeignKey(d => d.Placa)
                    .HasConstraintName("FK_HistorialEstado_Bien");
            });

            modelBuilder.Entity<HistorialPropietarios>(entity =>
            {
                entity.HasKey(e => e.IdHistorialPropietario);

                entity.Property(e => e.IdHistorialPropietario).ValueGeneratedNever();

                entity.Property(e => e.FechaHasta).HasColumnType("datetime");

                entity.Property(e => e.IdFuncionario)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdFuncionarioCambia)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Placa)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdFuncionarioNavigation)
                    .WithMany(p => p.HistorialPropietariosIdFuncionarioNavigation)
                    .HasForeignKey(d => d.IdFuncionario)
                    .HasConstraintName("FK_HistorialPropietarios_Funcionario");

                entity.HasOne(d => d.IdFuncionarioCambiaNavigation)
                    .WithMany(p => p.HistorialPropietariosIdFuncionarioCambiaNavigation)
                    .HasForeignKey(d => d.IdFuncionarioCambia)
                    .HasConstraintName("FK_HistorialPropietarios_Funcionario1");

                entity.HasOne(d => d.PlacaNavigation)
                    .WithMany(p => p.HistorialPropietarios)
                    .HasForeignKey(d => d.Placa)
                    .HasConstraintName("FK_HistorialPropietarios_Bien");
            });

            modelBuilder.Entity<Oficina>(entity =>
            {
                entity.HasKey(e => e.IdOficina);

                entity.Property(e => e.IdOficina).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RolXfuncionario>(entity =>
            {
                entity.HasKey(e => e.IdRolXfuncionario)
                    .HasName("PK_TRolXFuncionario");

                entity.ToTable("RolXFuncionario");

                entity.Property(e => e.IdRolXfuncionario).HasColumnName("IdRolXFuncionario");

                entity.Property(e => e.IdFuncionario)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdFuncionarioNavigation)
                    .WithMany(p => p.RolXfuncionario)
                    .HasForeignKey(d => d.IdFuncionario)
                    .HasConstraintName("FK_RolXFuncionario_Funcionario");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.RolXfuncionario)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("FK_RolXFuncionario_Roles");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.IdRol);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoBien>(entity =>
            {
                entity.HasKey(e => e.IdTipoBien);

                entity.Property(e => e.IdTipoBien).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoDepreciacion>(entity =>
            {
                entity.HasKey(e => e.IdTipoDepreciacion);

                entity.Property(e => e.IdTipoDepreciacion).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Formula)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TomaInventario>(entity =>
            {
                entity.HasKey(e => e.IdTomaInventario);

                entity.Property(e => e.IdTomaInventario).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.FechaFin).HasColumnType("datetime");

                entity.Property(e => e.FechaInicio).HasColumnType("datetime");

                entity.Property(e => e.IdFuncionario)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCentroCostoNavigation)
                    .WithMany(p => p.TomaInventario)
                    .HasForeignKey(d => d.IdCentroCosto)
                    .HasConstraintName("FK_TomaInventario_CentroCosto");

                entity.HasOne(d => d.IdFuncionarioNavigation)
                    .WithMany(p => p.TomaInventario)
                    .HasForeignKey(d => d.IdFuncionario)
                    .HasConstraintName("FK_TomaInventario_Funcionario");

                entity.HasOne(d => d.IdTomaInventarioNavigation)
                    .WithOne(p => p.TomaInventario)
                    .HasForeignKey<TomaInventario>(d => d.IdTomaInventario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TomaInventario_BienesIdentificados");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
