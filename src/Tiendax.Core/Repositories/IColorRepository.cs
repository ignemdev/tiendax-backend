using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendax.Core.Entities;

namespace Tiendax.Core.Repositories;

public interface IColorRepository : IRepository<Color>
{
    Task<Color> UpdateAsync(Color color);
    Task<Color> ToggleActivoById(int colorId);
    void UpdateRange(IEnumerable<Color> colores);
}
