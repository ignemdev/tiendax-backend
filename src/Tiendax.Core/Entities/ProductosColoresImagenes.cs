using System;
using System.Collections.Generic;

namespace Tiendax.Core.Entities
{
    public partial class ProductosColoresImagenes
    {
        public int ProductoId { get; set; }
        public int ColorId { get; set; }
        public string? Path { get; set; }

        public virtual Colores Color { get; set; } = null!;
        public virtual Productos Producto { get; set; } = null!;
    }
}
