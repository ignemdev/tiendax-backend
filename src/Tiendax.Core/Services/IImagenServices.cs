using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendax.Core.Entities;

namespace Tiendax.Core.Services;

public interface IImagenServices
{
    Task<IEnumerable<Imagen>> GetAllImagenesByVarianteId(int varianteId);
    Task<Imagen> AddImagen(Imagen imagen);
    Task<Imagen> UpdateImagen(Imagen imagen);
    Task<Imagen> GetImagenById(int imagenId);
    Task<Imagen> ToggleActivoById(int imagenId);
}
