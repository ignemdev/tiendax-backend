using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Tiendax.Core.Entities;

namespace Tiendax.Data;
public class TiendaxContext : DbContext
{
    public TiendaxContext()
    {
    }

    public TiendaxContext(DbContextOptions<TiendaxContext> options)
        : base(options)
    {
    }

    public DbSet<Caracteristica> Caracteristicas { get; set; } = null!;
    public DbSet<Categoria> Categorias { get; set; } = null!;
    public DbSet<Color> Colores { get; set; } = null!;
    public DbSet<Imagen> Imagenes { get; set; } = null!;
    public DbSet<Marca> Marcas { get; set; } = null!;
    public DbSet<Producto> Productos { get; set; } = null!;
    public DbSet<ProductoCaracteristica> ProductosCaracteristicas { get; set; } = null!;
    public DbSet<Variante> Variantes { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.AddCaracteristicasMapping();
        modelBuilder.AddCategoriasMapping();
        modelBuilder.AddColoresMapping();
        modelBuilder.AddImagenesMapping();
        modelBuilder.AddMarcasMapping();
        modelBuilder.AddProductosMapping();
        modelBuilder.AddVariantesMapping();
        modelBuilder.AddProductosCaracteristicasMapping();
    }
}
