using System;
using System.Collections.Generic;

namespace Tiendax.Core.Entities;
public class Caracteristica : BaseEntity
{
    public Caracteristica()
    {
        ProductosCaracteristicas = new List<ProductoCaracteristica>();
    }

    public string Descripcion { get; set; } = null!;

    public IEnumerable<ProductoCaracteristica> ProductosCaracteristicas { get; set; }
}
