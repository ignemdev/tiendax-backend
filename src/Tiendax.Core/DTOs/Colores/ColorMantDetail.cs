using Tiendax.Core.Entities;

namespace Tiendax.Core.DTOs.Colores;

public class ColorMantDetail : BaseEntity
{
    public string Descripcion { get; set; } = null!;
    public string Hex { get; set; } = null!;
}
