﻿using System;
using System.Collections.Generic;

namespace Tiendax.Core.Entities
{
    public class Caracteristica
    {
        public Caracteristica()
        {
            ProductosCaracteristicas = new List<ProductoCaracteristica>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public bool? Activo { get; set; }
        public DateTime? Creado { get; set; }
        public DateTime? Modificado { get; set; }

        public IEnumerable<ProductoCaracteristica> ProductosCaracteristicas { get; set; }
    }
}
