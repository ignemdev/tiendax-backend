using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendax.Core.Entities;

namespace Tiendax.Core.Repositories;

public interface IProductoRepository : IRepository<Producto>
{
    Task UpdateAsync(Producto producto);
    void UpdateRange(IEnumerable<Producto> productos);
}
