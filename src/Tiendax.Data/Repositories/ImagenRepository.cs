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

    public async Task UpdateAsync(Imagen imagen)
    {
        var dbImagen = await _db.Imagenes.FirstOrDefaultAsync(c => c.Id == imagen.Id);

        if (dbImagen == null)
            return;

        dbImagen.Path = imagen.Path ?? dbImagen.Path;
        dbImagen.VarianteId = imagen.VarianteId;

    }

    public void UpdateRange(IEnumerable<Imagen> imagenes)
    {
        if (!imagenes.Any())
            return;

        _db.Imagenes.UpdateRange(imagenes);
    }
}
