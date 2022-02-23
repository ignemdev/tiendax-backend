using System;
using System.Collections.Generic;

namespace Tiendax.Core.Entities
{
    public partial class Productos
    {
        public Productos()
        {
            ProductosCaracteristicas = new HashSet<ProductosCaracteristicas>();
            ProductosColoresImagenes = new HashSet<ProductosColoresImagenes>();
            ProductosColoresPrecios = new HashSet<ProductosColoresPrecios>();
            Categoria = new HashSet<Categorias>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Sku { get; set; }
        public int Stock { get; set; }
        public string Descripcion { get; set; } = null!;
        public int MarcaId { get; set; }
        public bool? Activo { get; set; }
        public DateTime? Creado { get; set; }
        public DateTime? Modificado { get; set; }

        public virtual Marcas Marca { get; set; } = null!;
        public virtual ICollection<ProductosCaracteristicas> ProductosCaracteristicas { get; set; }
        public virtual ICollection<ProductosColoresImagenes> ProductosColoresImagenes { get; set; }
        public virtual ICollection<ProductosColoresPrecios> ProductosColoresPrecios { get; set; }

        public virtual ICollection<Categorias> Categoria { get; set; }
    }
}
