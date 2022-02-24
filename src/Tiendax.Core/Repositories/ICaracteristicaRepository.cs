using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendax.Core.Entities;

namespace Tiendax.Core.Repositories;

public interface ICaracteristicaRepository : IRepository<Caracteristica>
{
    Task<Caracteristica> UpdateAsync(Caracteristica caracteristica);

    Task<Caracteristica> ToggleActivoById(int caracteristicaId);

    void UpdateRange(IEnumerable<Caracteristica> caracteristicas);
}
