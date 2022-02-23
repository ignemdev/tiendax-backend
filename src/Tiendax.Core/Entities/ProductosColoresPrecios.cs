using System;
using System.Collections.Generic;

namespace Tiendax.Core.Entities
{
    public partial class ProductosColoresPrecios
    {
        public int ProductoId { get; set; }
        public int ColorId { get; set; }
        public string? Precio { get; set; }

        public virtual Colores Color { get; set; } = null!;
        public virtual Productos Producto { get; set; } = null!;
    }
}
