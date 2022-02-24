using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendax.Core.Entities;

namespace Tiendax.Core.Services;

public interface ICaracteristicaServices
{
    Task<IEnumerable<Caracteristica>> GetAllActiveCaracteristicas();
    Task<Caracteristica> AddCaracteristica(Caracteristica caracteristica);
    Task<Caracteristica> UpdateCaracteristica(Caracteristica caracteristica);
    Task<Caracteristica> GetCaracteristicaById(int caracteristicaId);
    Task<Caracteristica> ToggleActivoById(int caracteristicaId);
}
