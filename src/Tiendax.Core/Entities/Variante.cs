using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Tiendax.Core.Entities;
    public class Variante : BaseEntity
{
    public Variante()
    {
        Imagenes = new Collection<Imagen>();
    }

    public int ProductoId { get; set; }

    [MinLength(8)]
    [Required(AllowEmptyStrings = false)]
    public string Sku { get; set; } = null!;
    public int Stock { get; set; }
    public double Precio { get; set; }
    public int? ColorId { get; set; }

    public Color? Color { get; set; } = null!;
    public Producto Producto { get; set; } = null!;
    public ICollection<Imagen> Imagenes { get; set; }
}
