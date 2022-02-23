using System;
using System.Collections.Generic;

namespace Tiendax.Core.Entities
{
    public partial class Categorias
    {
        public Categorias()
        {
            Producto = new HashSet<Productos>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public bool? Activo { get; set; }
        public DateTime? Creado { get; set; }
        public DateTime? Modificado { get; set; }

        public virtual ICollection<Productos> Producto { get; set; }
    }
}
