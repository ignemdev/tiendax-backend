using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendax.Core.DTOs.Colores;
using Tiendax.Core.DTOs.Imagenes;
using Tiendax.Core.Entities;

namespace Tiendax.Core.DTOs.Variantes;

public class VarianteMantDetail : BaseEntity
{
    public string Sku { get; set; } = null!;
    public int Stock { get; set; }
    public double Precio { get; set; }
    public ColorMantVariante? Color { get; set; } = null!;
}
