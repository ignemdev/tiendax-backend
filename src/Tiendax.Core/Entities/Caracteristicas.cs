using System;
using System.Collections.Generic;

namespace Tiendax.Core.Entities
{
    public partial class Caracteristicas
    {
        public Caracteristicas()
        {
            ProductosCaracteristicas = new HashSet<ProductosCaracteristicas>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public bool? Activo { get; set; }
        public DateTime? Creado { get; set; }
        public DateTime? Modificado { get; set; }

        public virtual ICollection<ProductosCaracteristicas> ProductosCaracteristicas { get; set; }
    }
}
