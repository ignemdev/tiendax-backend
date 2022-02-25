using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiendax.Core.DTOs.Variantes;

public class VarianteMantUpdate
{
    public int Id { get; set; }
    public int ProductoId { get; set; }
    public int? ColorId { get; set; }
    public string Sku { get; set; } = null!;
    public int Stock { get; set; }
    public double Precio { get; set; }
}
