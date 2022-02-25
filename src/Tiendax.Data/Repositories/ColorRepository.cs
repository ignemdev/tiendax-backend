using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendax.Core.Entities;
using Tiendax.Core.Repositories;

namespace Tiendax.Data.Repositories;

public class ColorRepository : Repository<Color>, IColorRepository
{
    private readonly TiendaxContext _db;
    public ColorRepository(TiendaxContext db) : base(db) => _db = db;

    public async Task<Color> UpdateAsync(Color Color)
    {
        var dbColor = await _db.Colores.FirstOrDefaultAsync(c => c.Id == Color.Id);

        if(dbColor != null)
        {
            dbColor!.Descripcion = Color.Descripcion ?? dbColor.Descripcion;
            dbColor!.Hex = Color.Hex ?? dbColor.Hex;
        }

        return dbColor!;
    }

    public async Task<Color> ToggleActivoById(int colorId)
    {
        var dbColor = await _db.Colores.FirstOrDefaultAsync(c => c.Id == colorId);

        if(dbColor != null)
        {
            dbColor!.Activo = !dbColor.Activo;
        }

        return dbColor!;
    }

    public void UpdateRange(IEnumerable<Color> colores)
    {
        if (!colores.Any())
            return;

        _db.Colores.UpdateRange(colores);
    }
}
