using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendax.Core.Entities;
using Tiendax.Core.Repositories;

namespace Tiendax.Data.Repositories;

public class CaracteristicaRepository : Repository<Caracteristica>, ICaracteristicaRepository
{
    private readonly TiendaxContext _db;

    public CaracteristicaRepository(TiendaxContext db) : base(db) => _db = db;

    public async Task<Caracteristica> UpdateAsync(Caracteristica caracteristica)
    {
        var dbCaracteristica = await _db.Caracteristicas.FirstOrDefaultAsync(c => c.Id == caracteristica.Id);

        dbCaracteristica!.Descripcion = caracteristica.Descripcion ?? dbCaracteristica.Descripcion;

        return dbCaracteristica;
    }

    public void UpdateRange(IEnumerable<Caracteristica> caracteristicas)
    {
        if (!caracteristicas.Any())
            return;

        _db.Caracteristicas.UpdateRange(caracteristicas);
    }

    public async Task<Caracteristica> ToggleActivoById(int caracteristicaId)
    {
        var dbCaracteristica = await _db.Caracteristicas.FirstOrDefaultAsync(c => c.Id == caracteristicaId);

        dbCaracteristica!.Activo = !dbCaracteristica.Activo;

        return dbCaracteristica;
    }
}
