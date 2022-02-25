using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Tiendax.Core.Entities;
public class Categoria : BaseEntity
{
    public Categoria()
    {
        Productos = new Collection<Producto>();
    }

    [MinLength(1)]
    [Required(AllowEmptyStrings = false)]
    public string Descripcion { get; set; } = null!;

    public ICollection<Producto> Productos { get; set; }
}
