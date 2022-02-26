using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tiendax.Core.Entities;
using Tiendax.Core.Models;

namespace Tiendax.Core.Repositories;

public interface IProductoRepository : IRepository<Producto>
{
    Task<Producto> UpdateAsync(Producto producto);
    Task<Producto> ToggleActivoById(int productoId);
    Task<Producto> AddCategorias(int productoId, IEnumerable<int> categoriasIds);
    Task<IEnumerable<Producto>> GetAllWithActiveCategorias(Expression<Func<Producto, bool>> predicate = null!);
    Task<ResponsePaginationModel<IEnumerable<Producto>>> GetAllPagedWithActiveCategorias(int limit, int page, CancellationToken cancellationToken, Expression<Func<Producto, bool>> predicate = null!);
    Task<Producto> GetFirstOrDefaultWithActiveCategorias(Expression<Func<Producto, bool>> predicate = null!);
    void UpdateRange(IEnumerable<Producto> productos);
}
