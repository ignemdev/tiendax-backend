using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiendax.Core.DTOs.Caracteristicas;

public class CaracteristicaMantUpdate
{
    public int Id { get; set; }
    public string Descripcion { get; set; } = null!;
}
