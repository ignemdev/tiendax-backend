using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Tiendax.Core.Entities;
public class Marca : BaseEntity
{
    public Marca()
    {
        Productos = new Collection<Producto>();
    }

    [MinLength(1)]
    [Required(AllowEmptyStrings = false)]
    public string Nombre { get; set; } = null!;

    public ICollection<Producto> Productos { get; set; }
};
