using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendax.Core.Entities;
using Tiendax.Core.Models;

namespace Tiendax.Core.Services;

public interface IProductoServices
{
    Task<IEnumerable<Producto>> GetAllProductosWithIncludes();
    Task<ResponsePaginationModel<IEnumerable<Producto>>> GetAllProductosPagedWithIncludes(int limit, int page, CancellationToken cancellationToken);
    Task<Producto> AddProducto(Producto producto);
    Task<Producto> UpdateProducto(Producto producto);
    Task<Producto> GetProductoById(int productoId);
    Task<Producto> ToggleActivoById(int productoId);
    Task<Producto> AddProductoCategorias(int productoId, IEnumerable<int> categoriasIds);
}
