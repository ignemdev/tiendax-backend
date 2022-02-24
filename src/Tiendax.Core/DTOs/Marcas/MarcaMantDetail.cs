using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendax.Core.Entities;

namespace Tiendax.Core.DTOs.Marcas;

public class MarcaMantDetail : BaseEntity
{
    public string Nombre { get; set; } = null!;
}
