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

    public async Task UpdateAsync(Variante variante)
    {
        var dbVariante = await _db.Variantes.FirstOrDefaultAsync(c => c.Id == variante.Id);

        if (dbVariante == null)
            return;

        dbVariante.Sku = variante.Sku ?? dbVariante.Sku;
        dbVariante.Stock = variante.Stock;
        dbVariante.Precio = variante.Precio;
        dbVariante.ColorId = variante.ColorId;
    }

    public void UpdateRange(IEnumerable<Variante> variantes)
    {
        if (!variantes.Any())
            return;

        _db.Variantes.UpdateRange(variantes);
    }
}
