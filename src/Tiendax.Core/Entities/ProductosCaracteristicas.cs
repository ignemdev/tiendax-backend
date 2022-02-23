using System;
using System.Collections.Generic;

namespace Tiendax.Core.Entities
{
    public partial class ProductosCaracteristicas
    {
        public int ProductoId { get; set; }
        public int CaracteristicaId { get; set; }
        public string Valor { get; set; } = null!;

        public virtual Caracteristicas Caracteristica { get; set; } = null!;
        public virtual Productos Producto { get; set; } = null!;
    }
}
