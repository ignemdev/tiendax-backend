using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendax.Core.Entities;

namespace System;

public static class MappingsExtensions
{
    public static ModelBuilder AddCategoriasMapping(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.ToTable("Categorias", "mant");

            entity.HasIndex(e => e.Descripcion).IsUnique();

            entity.Property(e => e.Creado).HasColumnType("datetime");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(e => e.Modificado).HasColumnType("datetime");
        });

        return modelBuilder;
    }

    public static ModelBuilder AddCaracteristicasMapping(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Caracteristica>(entity =>
        {
            entity.ToTable("Caracteristicas", "mant");

            entity.HasIndex(e => e.Descripcion).IsUnique();

            entity.Property(e => e.Creado).HasColumnType("datetime");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsRequired();

            entity.Property(e => e.Modificado).HasColumnType("datetime");

        });

        return modelBuilder;
    }

    public static ModelBuilder AddColoresMapping(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Color>(entity =>
        {
            entity.ToTable("Colores", "mant");

            entity.HasIndex(e => e.Hex).IsUnique();

            entity.Property(e => e.Creado).HasColumnType("datetime");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsRequired();

            entity.Property(e => e.Hex)
                .HasMaxLength(6)
                .IsRequired();

            entity.Property(e => e.Modificado).HasColumnType("datetime");
        });

        return modelBuilder;
    }

    public static ModelBuilder AddImagenesMapping(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Imagen>(entity =>
        {
            entity.ToTable("Imagenes", "mant");

            entity.Property(e => e.Creado).HasColumnType("datetime");

            entity.Property(e => e.Modificado).HasColumnType("datetime");

            entity.Property(e => e.Path).IsRequired();

            entity.HasOne(d => d.Variante)
                .WithMany(p => p.Imagenes)
                .HasForeignKey(d => d.VarianteId)
                .OnDelete(DeleteBehavior.ClientCascade);
        });

        return modelBuilder;
    }

    public static ModelBuilder AddMarcasMapping(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Marca>(entity =>
        {
            entity.ToTable("Marcas", "mant");

            entity.HasIndex(e => e.Nombre)
                .IsUnique();

            entity.Property(e => e.Creado).HasColumnType("datetime");

            entity.Property(e => e.Modificado).HasColumnType("datetime");

            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsRequired();
        });

        return modelBuilder;
    }

    public static ModelBuilder AddProductosMapping(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>(entity =>
        {
            entity.ToTable("Productos", "mant");

            entity.HasIndex(e => e.Nombre)
                .IsUnique();

            entity.Property(e => e.Creado).HasColumnType("datetime");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsRequired();

            entity.Property(e => e.Modificado).HasColumnType("datetime");

            entity.Property(e => e.Nombre)
                .HasMaxLength(250)
                .IsRequired();

            entity.HasOne(d => d.Marca)
                .WithMany(p => p.Productos)
                .HasForeignKey(d => d.MarcaId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(d => d.Categorias)
                .WithMany(p => p.Productos)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductosCategorias",
                    l => l.HasOne<Categoria>().WithMany().HasForeignKey("CategoriaId").OnDelete(DeleteBehavior.ClientSetNull),
                    r => r.HasOne<Producto>().WithMany().HasForeignKey("ProductoId").OnDelete(DeleteBehavior.ClientSetNull),
                    j =>
                    {
                        j.HasKey("ProductoId", "CategoriaId");

                        j.ToTable("ProductosCategorias", "mant");
                    });
        });

        return modelBuilder;
    }

    public static ModelBuilder AddVariantesMapping(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Variante>(entity =>
        {
            entity.ToTable("Variantes", "mant");

            entity.HasIndex(e => new { e.ProductoId, e.ColorId })
                .IsUnique();

            entity.HasIndex(e => e.Sku)
                .IsUnique();

            entity.Property(e => e.Creado).HasColumnType("datetime");

            entity.Property(e => e.Modificado).HasColumnType("datetime");

            entity.Property(e => e.Sku)
                .HasMaxLength(8)
                .IsRequired();

            entity.HasOne(d => d.Producto)
                .WithMany(p => p.Variantes)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        return modelBuilder;
    }

    public static ModelBuilder AddProductosCaracteristicasMapping(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductoCaracteristica>(entity =>
        {
            entity.HasKey(e => new { e.ProductoId, e.CaracteristicaId });

            entity.ToTable("ProductosCaracteristicas", "mant");

            entity.Property(e => e.Valor)
                .HasMaxLength(500)
                .IsRequired();

            entity.HasOne(d => d.Caracteristica)
                .WithMany(p => p.ProductosCaracteristicas)
                .HasForeignKey(d => d.CaracteristicaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductosCaracteristicas_Caracteristicas_CaracteristicaId");

            entity.HasOne(d => d.Producto)
                .WithMany(p => p.ProductosCaracteristicas)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductosCaracteristicas_Productos_ProductoId");
        });

        return modelBuilder;
    }
}

