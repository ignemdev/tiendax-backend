using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendax.Core.DTOs.Categorias;
using Tiendax.Core.DTOs.Marcas;
using Tiendax.Core.Entities;

namespace Tiendax.Core.DTOs.Productos;

public class ProductoMantDetail : BaseEntity
{
    public ProductoMantDetail()
    {
        Categorias = new List<CategoriaMantProducto>();
    }
    public string Nombre { get; set; } = null!;
    public string Descripcion { get; set; } = null!;
    public MarcaMantProducto Marca { get; set; } = null!;
    public IEnumerable<CategoriaMantProducto> Categorias { get; set; }
}
