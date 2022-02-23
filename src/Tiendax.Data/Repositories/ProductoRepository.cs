using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendax.Core.Entities;
using Tiendax.Core.Repositories;

namespace Tiendax.Data.Repositories;

public class ProductoRepository : Repository<Producto>, IProductoRepository
{
    private readonly TiendaxContext _db;
    public ProductoRepository(TiendaxContext db) : base(db) => _db = db;

    public async Task UpdateAsync(Producto productos)
    {
        var dbProducto = await _db.Productos.FirstOrDefaultAsync(c => c.Id == productos.Id);

        if (dbProducto == null)
            return;

        dbProducto.Nombre = productos.Nombre ?? dbProducto.Nombre;   
        dbProducto.Descripcion = productos.Descripcion ?? dbProducto.Descripcion;
        dbProducto.MarcaId = productos.MarcaId;
    }

    public void UpdateRange(IEnumerable<Producto> productos)
    {
        if (!productos.Any())
            return;

        _db.Productos.UpdateRange(productos);
    }
}
