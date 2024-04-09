using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WEB_API_DAVIDVEGA_EC2.Models;

public partial class LifeSureContext : DbContext
{
    public LifeSureContext()
    {
    }

    public LifeSureContext(DbContextOptions<LifeSureContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-HTLQADJ\\KENSHINHIMURA;Initial Catalog=LifeSure;User ID=sa;Password=2592000;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.CategoriaId).HasName("PK__Categori__F353C1C568BF5679");

            entity.Property(e => e.CategoriaId)
                .ValueGeneratedNever()
                .HasColumnName("CategoriaID");
            entity.Property(e => e.NombreCategoria).HasMaxLength(50);
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.MarcaId).HasName("PK__Marca__D5B1CDEB7C688B7A");

            entity.ToTable("Marca");

            entity.Property(e => e.MarcaId)
                .ValueGeneratedNever()
                .HasColumnName("MarcaID");
            entity.Property(e => e.NombreMarca).HasMaxLength(50);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.ProductoId).HasName("PK__Producto__A430AE8344096BD1");

            entity.ToTable("Producto");

            entity.Property(e => e.ProductoId)
                .ValueGeneratedNever()
                .HasColumnName("ProductoID");
            entity.Property(e => e.CategoriaId).HasColumnName("CategoriaID");
            entity.Property(e => e.MarcaId).HasColumnName("MarcaID");
            entity.Property(e => e.NombreProducto).HasMaxLength(100);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CategoriaId)
                .HasConstraintName("FK__Producto__Catego__3B75D760");

            entity.HasOne(d => d.Marca).WithMany(p => p.Productos)
                .HasForeignKey(d => d.MarcaId)
                .HasConstraintName("FK__Producto__MarcaI__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
