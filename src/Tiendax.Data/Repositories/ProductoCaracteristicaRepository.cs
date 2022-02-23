using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendax.Core.Entities;
using Tiendax.Core.Repositories;

namespace Tiendax.Data.Repositories;

public class ProductoCaracteristicaRepository : Repository<ProductoCaracteristica>, IProductoCaracteristicaRepository
{
    private readonly TiendaxContext _db;
    public ProductoCaracteristicaRepository(TiendaxContext db) : base(db) => _db = db;

    public async Task UpdateAsync(ProductoCaracteristica productoCaracteristica)
    {
        var dbProductoCaracteristica = await _db.ProductosCaracteristicas
            .FirstOrDefaultAsync(p => p.ProductoId == productoCaracteristica.ProductoId &&
                            p.CaracteristicaId == productoCaracteristica.CaracteristicaId);

        if (dbProductoCaracteristica == null)
            return;

        dbProductoCaracteristica.Valor = productoCaracteristica.Valor ?? dbProductoCaracteristica.Valor;
    }

    public void UpdateRange(IEnumerable<ProductoCaracteristica> productoCaracteristicas)
    {
        throw new NotImplementedException();
    }
}
