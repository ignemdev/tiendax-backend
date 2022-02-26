using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiendax.Core.Models;

public abstract class PaginationParams
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 50; 
}
