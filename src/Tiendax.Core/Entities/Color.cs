using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Tiendax.Core.Entities;
public class Color : BaseEntity
{
    [MinLength(1)]
    [Required(AllowEmptyStrings = false)]
    public string Descripcion { get; set; } = null!;

    [MinLength(6)]
    [MaxLength(6)]
    [Required(AllowEmptyStrings = false)]
    public string Hex { get; set; } = null!;
}
