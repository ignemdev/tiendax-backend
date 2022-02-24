using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tiendax.Core.Entities;
public class Color : BaseEntity
{
    [MinLength(1)]
    [Required(AllowEmptyStrings = false)]
    public string Descripcion { get; set; } = null!;

    [MinLength(1)]
    [Required(AllowEmptyStrings = false)]
    public string Hex { get; set; } = null!;
}
