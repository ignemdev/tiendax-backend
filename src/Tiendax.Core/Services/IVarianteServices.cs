using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendax.Core.Entities;

namespace Tiendax.Core.Services;

public interface IVarianteServices
{
    Task<IEnumerable<Variante>> GetAllVariantes();
    Task<Variante> AddVariante(Variante variante);
    Task<Variante> UpdateVariante(Variante variante);
    Task<Variante> GetVarianteById(int varianteId);
    Task<Variante> ToggleActivoById(int varianteId);
}
