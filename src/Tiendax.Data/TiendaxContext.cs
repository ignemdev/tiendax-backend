using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Tiendax.Core.Entities;

namespace Tiendax.Data
{
    public partial class TiendaxContext : DbContext
    {
        public TiendaxContext()
        {
        }

        public TiendaxContext(DbContextOptions<TiendaxContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Caracteristicas> Caracteristicas { get; set; } = null!;
        public virtual DbSet<Categorias> Categorias { get; set; } = null!;
        public virtual DbSet<Colores> Colores { get; set; } = null!;
        public virtual DbSet<Imagenes> Imagenes { get; set; } = null!;
        public virtual DbSet<Marcas> Marcas { get; set; } = null!;
        public virtual DbSet<Productos> Productos { get; set; } = null!;
        public virtual DbSet<ProductosCaracteristicas> ProductosCaracteristicas { get; set; } = null!;
        public virtual DbSet<Variantes> Variantes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:TiendaxConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Caracteristicas>(entity =>
            {
                entity.ToTable("Caracteristicas", "mant");

                entity.HasIndex(e => e.Descripcion, "UK_Caracteristicas_Descripcion")
                    .IsUnique();

                entity.Property(e => e.Creado).HasColumnType("datetime");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Modificado).HasColumnType("datetime");
            });

            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.ToTable("Categorias", "mant");

                entity.HasIndex(e => e.Descripcion, "UK_Categorias_Descripcion")
                    .IsUnique();

                entity.Property(e => e.Creado).HasColumnType("datetime");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Modificado).HasColumnType("datetime");
            });

            modelBuilder.Entity<Colores>(entity =>
            {
                entity.ToTable("Colores", "mant");

                entity.HasIndex(e => e.Hex, "UK_Colores_Hex")
                    .IsUnique();

                entity.Property(e => e.Creado).HasColumnType("datetime");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Hex)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Modificado).HasColumnType("datetime");
            });

            modelBuilder.Entity<Imagenes>(entity =>
            {
                entity.ToTable("Imagenes", "mant");

                entity.Property(e => e.Creado).HasColumnType("datetime");

                entity.Property(e => e.Modificado).HasColumnType("datetime");

                entity.Property(e => e.Path).IsUnicode(false);

                entity.HasOne(d => d.Variante)
                    .WithMany(p => p.Imagenes)
                    .HasForeignKey(d => d.VarianteId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Marcas>(entity =>
            {
                entity.ToTable("Marcas", "mant");

                entity.HasIndex(e => e.Nombre, "UK_Marcas_Nombre")
                    .IsUnique();

                entity.Property(e => e.Creado).HasColumnType("datetime");

                entity.Property(e => e.Modificado).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Productos>(entity =>
            {
                entity.ToTable("Productos", "mant");

                entity.HasIndex(e => e.Nombre, "UK_Productos_Nombre")
                    .IsUnique();

                entity.Property(e => e.Creado).HasColumnType("datetime");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Modificado).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Sku)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.HasOne(d => d.Marca)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.MarcaId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasMany(d => d.Categoria)
                    .WithMany(p => p.Producto)
                    .UsingEntity<Dictionary<string, object>>(
                        "ProductosCategorias",
                        l => l.HasOne<Categorias>().WithMany().HasForeignKey("CategoriaId").OnDelete(DeleteBehavior.ClientSetNull),
                        r => r.HasOne<Productos>().WithMany().HasForeignKey("ProductoId").OnDelete(DeleteBehavior.ClientSetNull),
                        j =>
                        {
                            j.HasKey("ProductoId", "CategoriaId");

                            j.ToTable("ProductosCategorias", "mant");
                        });
            });

            modelBuilder.Entity<ProductosCaracteristicas>(entity =>
            {
                entity.HasKey(e => new { e.ProductoId, e.CaracteristicaId });

                entity.ToTable("ProductosCaracteristicas", "mant");

                entity.Property(e => e.Valor)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Caracteristica)
                    .WithMany(p => p.ProductosCaracteristicas)
                    .HasForeignKey(d => d.CaracteristicaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductosCaracteristicas_Caracteristica_CaracteristicaId");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.ProductosCaracteristicas)
                    .HasForeignKey(d => d.ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Variantes>(entity =>
            {
                entity.ToTable("Variantes", "mant");

                entity.HasIndex(e => new { e.ProductoId, e.ColorId }, "UK_Variantes_ProductoId_ColorId")
                    .IsUnique();

                entity.HasIndex(e => e.Sku, "UK_Variantes_Sku")
                    .IsUnique();

                entity.Property(e => e.Creado).HasColumnType("datetime");

                entity.Property(e => e.Modificado).HasColumnType("datetime");

                entity.Property(e => e.Sku)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.Variantes)
                    .HasForeignKey(d => d.ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
