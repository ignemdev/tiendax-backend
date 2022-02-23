using System;
using System.Collections.Generic;

namespace Tiendax.Core.Entities;
public class Color : BaseEntity
{
    public string Descripcion { get; set; } = null!;
    public string Hex { get; set; } = null!;
}
