using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendax.Core.Entities;

namespace Tiendax.Core.Repositories;

public interface IImagenRepository : IRepository<Imagen>
{
    Task UpdateAsync(Imagen imagen);
    void UpdateRange(IEnumerable<Imagen> imagenes);
}
