using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tiendax.Core.Entities;
public class Imagen : BaseEntity
{
    [MinLength(1)]
    [Required(AllowEmptyStrings = false)]
    public string Path { get; set; } = null!;
    public int VarianteId { get; set; }

    public Variante Variante { get; set; } = null!;
}
