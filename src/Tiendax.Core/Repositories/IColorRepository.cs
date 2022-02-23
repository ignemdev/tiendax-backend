using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendax.Core.Entities;

namespace Tiendax.Core.Repositories;

public interface IColorRepository : IRepository<Color>
{
    Task UpdateAsync(Color color);
    void UpdateRange(IEnumerable<Color> colores);
}
