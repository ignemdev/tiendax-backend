using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tiendax.Core.Entities;
public class ProductoCaracteristica
{
    public int ProductoId { get; set; }
    public int CaracteristicaId { get; set; }

    [MinLength(1)]
    [Required(AllowEmptyStrings = false)]
    public string Valor { get; set; } = null!;

    public Caracteristica Caracteristica { get; set; } = null!;
    public Producto Producto { get; set; } = null!;
}
