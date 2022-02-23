using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendax.Core.Repositories;

namespace Tiendax.Core;

public interface IUnitOfWork : IDisposable
{
    ICaracteristicaRepository Caracteristica { get; }
    ICategoriaRepository Categoria { get; }
    IColorRepository Color { get; }
    IImagenRepository Imagen{ get; }
    IMarcaRepository Marca { get; }
    IProductoRepository Producto { get; }
    IVarianteRepository Variante { get; }
    IProductoCaracteristicaRepository ProductoCaracteristica { get; }
    Task SaveAsync();
}
