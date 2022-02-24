using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tiendax.Core.Entities;

public class Caracteristica : BaseEntity
{
    public Caracteristica()
    {
        ProductosCaracteristicas = new List<ProductoCaracteristica>();
    }

    [MinLength(1)]
    [Required(AllowEmptyStrings = false)]
    public string Descripcion { get; set; } = null!;

    public IEnumerable<ProductoCaracteristica> ProductosCaracteristicas { get; set; }
}
