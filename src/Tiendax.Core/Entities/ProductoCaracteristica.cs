using System;
using System.Collections.Generic;

namespace Tiendax.Core.Entities;
public class ProductoCaracteristica
{
    public int ProductoId { get; set; }
    public int CaracteristicaId { get; set; }
    public string Valor { get; set; } = null!;

    public Caracteristica Caracteristica { get; set; } = null!;
    public Producto Producto { get; set; } = null!;
}
