using System;
using System.Collections.Generic;

namespace Tiendax.Core.Entities
{
    public class Imagen
    {
        public int Id { get; set; }
        public string Path { get; set; } = null!;
        public int VarianteId { get; set; }
        public bool? Activo { get; set; }
        public DateTime? Creado { get; set; }
        public DateTime? Modificado { get; set; }

        public Variante Variante { get; set; } = null!;
    }
}
