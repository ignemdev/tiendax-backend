using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendax.Core.Entities;

namespace Tiendax.Core.Repositories;

public interface IVarianteRepository : IRepository<Variante>
{
    Task UpdateAsync(Variante variante);
    void UpdateRange(IEnumerable<Variante> variantes);
}
