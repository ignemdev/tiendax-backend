using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendax.Core.Entities;
using Tiendax.Core.Repositories;

namespace Tiendax.Data.Repositories;

public class ImagenRepository : Repository<Imagen>, IImagenRepository
{
    private readonly TiendaxContext _db;
    public ImagenRepository(TiendaxContext db) : base(db) => _db = db;

    public async Task<Imagen> UpdateAsync(Imagen imagen)
    {
        var dbImagen = await _db.Imagenes.FirstOrDefaultAsync(i => i.Id == imagen.Id);


        if(dbImagen != null)
        {
            dbImagen!.Path = imagen.Path ?? dbImagen.Path;
            dbImagen!.VarianteId = imagen.VarianteId;
        }

        return dbImagen!;
    }
    public async Task<Imagen> ToggleActivoById(int imagenId)
    {
        var dbImagen = await _db.Imagenes.FirstOrDefaultAsync(i => i.Id == imagenId);

        if (dbImagen != null)
            dbImagen!.Activo = !dbImagen.Activo;

        return dbImagen!;
    }
    public void UpdateRange(IEnumerable<Imagen> imagenes)
    {
        if (!imagenes.Any())
            return;

        _db.Imagenes.UpdateRange(imagenes);
    }
}
