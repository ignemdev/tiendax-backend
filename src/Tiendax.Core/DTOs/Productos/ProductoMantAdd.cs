﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiendax.Core.DTOs.Productos;

public class ProductoMantAdd
{
    public string Nombre { get; set; } = null!;
    public string Descripcion { get; set; } = null!;
    public int MarcaId { get; set; }
}
