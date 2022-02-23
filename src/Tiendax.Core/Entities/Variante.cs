using System;
using System.Collections.Generic;

namespace Tiendax.Core.Entities
{
    public class Variante
    {
        public Variante()
        {
            Imagenes = new List<Imagen>();
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

        public Producto Producto { get; set; } = null!;
        public IEnumerable<Imagen> Imagenes { get; set; }
    }
}
