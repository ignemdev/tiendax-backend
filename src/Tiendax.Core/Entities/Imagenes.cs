using System;
using System.Collections.Generic;

namespace Tiendax.Core.Entities
{
    public partial class Imagenes
    {
        public int Id { get; set; }
        public string Path { get; set; } = null!;
        public int VarianteId { get; set; }
        public bool? Activo { get; set; }
        public DateTime? Creado { get; set; }
        public DateTime? Modificado { get; set; }

        public virtual Variantes Variante { get; set; } = null!;
    }
}
