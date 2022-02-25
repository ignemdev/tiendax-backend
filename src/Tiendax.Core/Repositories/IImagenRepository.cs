using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendax.Core.Entities;

namespace Tiendax.Core.Repositories;

public interface IImagenRepository : IRepository<Imagen>
{
    Task<Imagen> UpdateAsync(Imagen imagen);
    Task<Imagen> ToggleActivoById(int imagenId);
    void UpdateRange(IEnumerable<Imagen> imagenes);
}
