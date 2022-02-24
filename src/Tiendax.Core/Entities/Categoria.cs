using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tiendax.Core.Entities;
public class Categoria : BaseEntity
{
    public Categoria()
    {
        Productos = new List<Producto>();
    }

    [MinLength(1)]
    [Required(AllowEmptyStrings = false)]
    public string Descripcion { get; set; } = null!;

    public IEnumerable<Producto> Productos { get; set; }
}
