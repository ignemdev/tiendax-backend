using System;
using System.Collections.Generic;

namespace Tiendax.Core.Entities
{
    public partial class Marcas
    {
        public Marcas()
        {
            Productos = new HashSet<Productos>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public bool? Activo { get; set; }
        public DateTime? Creado { get; set; }
        public DateTime? Modificado { get; set; }

        public virtual ICollection<Productos> Productos { get; set; }
    }
}
