using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendax.Core.Entities;

namespace Tiendax.Core.Repositories;

public interface IProductoCaracteristicaRepository : IRepository<ProductoCaracteristica>
{
    Task UpdateAsync(ProductoCaracteristica productoCaracteristica);
    void UpdateRange(IEnumerable<ProductoCaracteristica> productoCaracteristicas);
}
