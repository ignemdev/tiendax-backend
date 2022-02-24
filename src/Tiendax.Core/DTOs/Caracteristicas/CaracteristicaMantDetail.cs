using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendax.Core.Entities;

namespace Tiendax.Core.DTOs.Caracteristicas;

public class CaracteristicaMantDetail : BaseEntity
{
    public string Descripcion { get; set; } = null!;
}
