using System;
using System.Collections.Generic;

namespace Tiendax.Core.Entities
{
    public partial class Productos
    {
        public Productos()
        {
            ProductosCaracteristicas = new HashSet<ProductosCaracteristicas>();
            Variantes = new HashSet<Variantes>();
            Categoria = new HashSet<Categorias>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Sku { get; set; } = null!;
        public int Stock { get; set; }
        public string Descripcion { get; set; } = null!;
        public int MarcaId { get; set; }
        public bool? Activo { get; set; }
        public DateTime? Creado { get; set; }
        public DateTime? Modificado { get; set; }

        public virtual Marcas Marca { get; set; } = null!;
        public virtual ICollection<ProductosCaracteristicas> ProductosCaracteristicas { get; set; }
        public virtual ICollection<Variantes> Variantes { get; set; }

        public virtual ICollection<Categorias> Categoria { get; set; }
    }
}
