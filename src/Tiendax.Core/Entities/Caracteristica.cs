using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tiendax.Core.Entities;

public class Caracteristica : BaseEntity
{
    public Caracteristica()
    {
        ProductosCaracteristicas = new Collection<ProductoCaracteristica>();
    }

    [MinLength(1)]
    [Required(AllowEmptyStrings = false)]
    public string Descripcion { get; set; } = null!;

    public ICollection<ProductoCaracteristica> ProductosCaracteristicas { get; set; }
}
