using System;
using System.Collections.Generic;

namespace Tiendax.Core.Entities;
public class Categoria : BaseEntity
{
    public Categoria()
    {
        Productos = new List<Producto>();
    }

    public string Descripcion { get; set; } = null!;

    public IEnumerable<Producto> Productos { get; set; }
}
