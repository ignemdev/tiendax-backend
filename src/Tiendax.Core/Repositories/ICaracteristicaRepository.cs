using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendax.Core.Entities;

namespace Tiendax.Core.Repositories;

public interface ICaracteristicaRepository : IRepository<Caracteristica>
{
    Task UpdateAsync(Caracteristica caracteristica);
    void UpdateRange(IEnumerable<Caracteristica> caracteristica);
}
