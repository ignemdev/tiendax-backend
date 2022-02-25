using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendax.Core.Entities;
using Tiendax.Core.Repositories;

namespace Tiendax.Data.Repositories;

public class MarcaRepository : Repository<Marca>, IMarcaRepository
{
    private readonly TiendaxContext _db;
    public MarcaRepository(TiendaxContext db) : base(db) => _db = db;

    public async Task<Marca> UpdateAsync(Marca marca)
    {
        var dbMarca = await _db.Marcas.FirstOrDefaultAsync(m => m.Id == marca.Id);

        dbMarca!.Nombre = marca.Nombre ?? dbMarca.Nombre;

        return dbMarca;
    }

    public async Task<Marca> ToggleActivoById(int marcaId)
    {
        var dbMarca = await _db.Marcas.Include("Productos").FirstOrDefaultAsync(m => m.Id == marcaId);

        dbMarca!.Activo = !dbMarca.Activo;
        //descativar productos
        return dbMarca;
    }

    public void UpdateRange(IEnumerable<Marca> marcas)
    {
        if (!marcas.Any())
            return;

        _db.Marcas.UpdateRange(marcas);
    }
}
