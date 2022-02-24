using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Tiendax.Core.Entities;

namespace Tiendax.Data;
public class TiendaxContext : DbContext
{
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

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entityEntry in ChangeTracker.Entries<BaseEntity>())
        {
            if (entityEntry.State == EntityState.Added)
            {
                entityEntry.Entity.Creado = DateTime.Now;
                entityEntry.Entity.Modificado = DateTime.Now;
            }
            else if (entityEntry.State == EntityState.Modified)
            {
                entityEntry.Entity.Modificado = DateTime.Now;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}
