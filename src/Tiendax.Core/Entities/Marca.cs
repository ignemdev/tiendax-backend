using System;
using System.Collections.Generic;

namespace Tiendax.Core.Entities;
public class Marca : BaseEntity
{
    public Marca()
    {
        Productos = new List<Producto>();
    }

    public string Nombre { get; set; } = null!;

    public IEnumerable<Producto> Productos { get; set; }
};
