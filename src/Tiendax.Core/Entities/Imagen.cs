using System;
using System.Collections.Generic;

namespace Tiendax.Core.Entities;
public class Imagen : BaseEntity
{
    public string Path { get; set; } = null!;
    public int VarianteId { get; set; }

    public Variante Variante { get; set; } = null!;
}
