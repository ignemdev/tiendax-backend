using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tiendax.Core.Entities;
public class Marca : BaseEntity
{
    public Marca()
    {
        Productos = new List<Producto>();
    }

    [MinLength(1)]
    [Required(AllowEmptyStrings = false)]
    public string Nombre { get; set; } = null!;

    public IEnumerable<Producto> Productos { get; set; }
};
