using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendax.Core.Entities;

namespace Tiendax.Core.Repositories;

public interface IMarcaRepository : IRepository<Marca>
{
    Task<Marca> UpdateAsync(Marca marca);
    Task<Marca> ToggleActivoById(int marcaId);
    void UpdateRange(IEnumerable<Marca> marca);
}
