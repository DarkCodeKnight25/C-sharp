using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVeterinariaAPI.Models;

public partial class ExamenFinalContext : DbContext
{
    public ExamenFinalContext()
    {
    }

    public ExamenFinalContext(DbContextOptions<ExamenFinalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cita> Citas { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<HistorialMedico> HistorialMedicos { get; set; }

    public virtual DbSet<Mascota> Mascotas { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-HTLQADJ\\KENSHINHIMURA;Initial Catalog=EXAMEN_FINAL;User ID=sa;Password=2592000;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasKey(e => e.Idcita).HasName("PK__Citas__36D350AB522E5B1C");

            entity.Property(e => e.Idcita)
                .ValueGeneratedNever()
                .HasColumnName("IDCita");
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.Idmascota).HasColumnName("IDMascota");
            entity.Property(e => e.MotivoConsulta)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdmascotaNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.Idmascota)
                .HasConstraintName("FK__Citas__IDMascota__3C69FB99");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Idcliente).HasName("PK__Clientes__9B8553FCD6880371");

            entity.Property(e => e.Idcliente)
                .ValueGeneratedNever()
                .HasColumnName("IDCliente");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HistorialMedico>(entity =>
        {
            entity.HasKey(e => e.Idhistorial).HasName("PK__Historia__C4BEFB6993179095");

            entity.ToTable("HistorialMedico");

            entity.Property(e => e.Idhistorial)
                .ValueGeneratedNever()
                .HasColumnName("IDHistorial");
            entity.Property(e => e.Diagnostico)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Idcita).HasColumnName("IDCita");
            entity.Property(e => e.Tratamiento)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdcitaNavigation).WithMany(p => p.HistorialMedicos)
                .HasForeignKey(d => d.Idcita)
                .HasConstraintName("FK__Historial__IDCit__412EB0B6");
        });

        modelBuilder.Entity<Mascota>(entity =>
        {
            entity.HasKey(e => e.Idmascota).HasName("PK__Mascotas__21EC2E63C0469F87");

            entity.Property(e => e.Idmascota)
                .ValueGeneratedNever()
                .HasColumnName("IDMascota");
            entity.Property(e => e.Especie)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaNacimiento).HasColumnType("date");
            entity.Property(e => e.Idcliente).HasColumnName("IDCliente");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Raza)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdclienteNavigation).WithMany(p => p.Mascota)
                .HasForeignKey(d => d.Idcliente)
                .HasConstraintName("FK__Mascotas__IDClie__398D8EEE");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.Idservicio).HasName("PK__Servicio__3CCE7416ED944EAC");

            entity.Property(e => e.Idservicio)
                .ValueGeneratedNever()
                .HasColumnName("IDServicio");
            entity.Property(e => e.Costo).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NombreServicio)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
