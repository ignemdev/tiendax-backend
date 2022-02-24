using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendax.Core.Entities;

namespace Tiendax.Core.Services;

public interface IMarcaServices
{
    Task<IEnumerable<Marca>> GetAllActiveMarcas();
    Task<Marca> AddMarca(Marca marca);
    Task<Marca> UpdateMarca(Marca marca);
    Task<Marca> GetMarcaById(int marcaId);
    Task<Marca> ToggleActivoById(int marcaId);
}
