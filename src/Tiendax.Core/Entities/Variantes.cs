using System;
using System.Collections.Generic;

namespace Tiendax.Core.Entities
{
    public partial class Variantes
    {
        public Variantes()
        {
            Imagenes = new HashSet<Imagenes>();
        }

        public int Id { get; set; }
        public int ProductoId { get; set; }
        public string Sku { get; set; } = null!;
        public int Stock { get; set; }
        public double Precio { get; set; }
        public int? ColorId { get; set; }
        public bool? Activo { get; set; }
        public DateTime? Creado { get; set; }
        public DateTime? Modificado { get; set; }

        public virtual Productos Producto { get; set; } = null!;
        public virtual ICollection<Imagenes> Imagenes { get; set; }
    }
}
