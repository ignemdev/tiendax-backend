using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tiendax.Core.Entities;
using Tiendax.Core.Enumerables;
using Tiendax.Core.Repositories;

namespace Tiendax.Data.Repositories;

public class ProductoRepository : Repository<Producto>, IProductoRepository
{
    private readonly TiendaxContext _db;
    public ProductoRepository(TiendaxContext db) : base(db) => _db = db;


    public async Task<Producto> UpdateAsync(Producto productos)
    {
        var dbProducto = await _db.Productos.Include("Marca")
                                            .Include("Categorias")
                                            .FirstOrDefaultAsync(p => p.Id == productos.Id);
        if(dbProducto != null)
        {
            dbProducto!.Nombre = productos.Nombre ?? dbProducto.Nombre;
            dbProducto!.Descripcion = productos.Descripcion ?? dbProducto.Descripcion;
            dbProducto!.MarcaId = productos.MarcaId;
        }

        return dbProducto!;
    }
    public async Task<Producto> ToggleActivoById(int productoId)
    {
        var dbProducto = await _db.Productos.Include("Marca")
                                            .Include("Categorias")
                                            .Include("Variantes")
                                            .FirstOrDefaultAsync(p => p.Id == productoId);

        if(dbProducto != null)
        {
            dbProducto!.Activo = !dbProducto.Activo;
        }

        return dbProducto!;
    }

    public async Task<Producto> AddCategorias(int productoId, IEnumerable<int> categoriasIds)
    {
        var dbProducto = await _db.Productos.Include("Marca")
                                            .Include("Categorias")
                                            .FirstOrDefaultAsync(p => p.Id == productoId);

        if(dbProducto != null)
        {
            var dbCategorias = await _db.Categorias.Where(c => categoriasIds.Contains(c.Id)).ToListAsync();

            if(dbCategorias.Any())
                dbCategorias.ForEach(c => dbProducto.Categorias.Add(c));
        }

        return dbProducto!;
    }

    public void UpdateRange(IEnumerable<Producto> productos)
    {
        if (!productos.Any())
            return;

        _db.Productos.UpdateRange(productos);
    }

    public async Task<IEnumerable<Producto>> GetAllWithActiveCategorias(Expression<Func<Producto, bool>> predicate = null!)
    {
        IQueryable<Producto> query = _db.Productos;

        if(predicate != null)
            query = query.Where(predicate);

        var productos = await query
            .Include("Marca")
            .Include(p => p.Categorias.Where(c => c.Activo == Convert.ToBoolean((int)Estado.Activo)))
            .ToListAsync();

        return productos;
    }

    public async Task<Producto> GetFirstOrDefaultWithActiveCategorias(Expression<Func<Producto, bool>> predicate = null!)
    {
        IQueryable<Producto> query = _db.Productos;

        if (predicate != null)
            query = query.Where(predicate);

        var dbProducto = await _db.Productos
            .Include("Marca")
            .Include(p => p.Categorias.Where(c => c.Activo == Convert.ToBoolean((int)Estado.Activo)))
            .FirstOrDefaultAsync();

        return dbProducto!;
    }
}
