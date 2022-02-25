using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendax.Core.Entities;
using Tiendax.Core.Repositories;

namespace Tiendax.Data.Repositories;

public class VarianteRepository : Repository<Variante>, IVarianteRepository
{
    private readonly TiendaxContext _db;
    public VarianteRepository(TiendaxContext db) : base(db) => _db = db;

    public async Task<Variante> ToggleActivoById(int varianteId)
    {
        var dbVariante = await _db.Variantes.Include("Color").FirstOrDefaultAsync(v => v.Id == varianteId);

        if (dbVariante != null)
        {
            dbVariante!.Activo = !dbVariante.Activo;
        }

        return dbVariante!;
    }

    public async Task<Variante> UpdateAsync(Variante variante)
    {
        var dbVariante = await _db.Variantes.Include("Color").FirstOrDefaultAsync(v => v.Id == variante.Id);

        if(dbVariante != null)
        {
            dbVariante!.Sku = variante.Sku ?? dbVariante.Sku;
            dbVariante!.Stock = variante.Stock;
            dbVariante!.Precio = variante.Precio;
            dbVariante!.ColorId = variante.ColorId;
        }

        return dbVariante!;
    }

    public void UpdateRange(IEnumerable<Variante> variantes)
    {
        if (!variantes.Any())
            return;

        _db.Variantes.UpdateRange(variantes);
    }
}
