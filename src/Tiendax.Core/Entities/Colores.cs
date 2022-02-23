using System;
using System.Collections.Generic;

namespace Tiendax.Core.Entities
{
    public partial class Colores
    {
        public Colores()
        {
            ProductosColoresImagenes = new HashSet<ProductosColoresImagenes>();
            ProductosColoresPrecios = new HashSet<ProductosColoresPrecios>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public string Hex { get; set; } = null!;
        public bool? Activo { get; set; }
        public DateTime? Creado { get; set; }
        public DateTime? Modificado { get; set; }

        public virtual ICollection<ProductosColoresImagenes> ProductosColoresImagenes { get; set; }
        public virtual ICollection<ProductosColoresPrecios> ProductosColoresPrecios { get; set; }
    }
}
