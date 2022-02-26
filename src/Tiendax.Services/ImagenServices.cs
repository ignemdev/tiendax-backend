using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendax.Core;
using Tiendax.Core.Entities;
using Tiendax.Core.Services;

namespace Tiendax.Services;

public class ImagenServices : IImagenServices
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IConfiguration _configuration;
    public ImagenServices(
        IConfiguration configuration,
        IUnitOfWork unitOfWork)
    {
        _configuration = configuration;
        _unitOfWork = unitOfWork;
    }

    public async Task<Imagen> AddImagen(Imagen imagen)
    {
        var errors = new List<ValidationResult>();
        if (!Validator.TryValidateObject(imagen, new ValidationContext(imagen), errors, true))
            throw new InvalidOperationException(string.Join(Environment.NewLine, errors.Select(x => x.ErrorMessage)));

        if (imagen == null)
            throw new ArgumentNullException(_configuration["Mensajes:E001"]);

        var addedImagen = await _unitOfWork.Imagen.AddAsync(imagen);
        await _unitOfWork.SaveAsync();

        return addedImagen;
    }

    public async Task<IEnumerable<Imagen>> GetAllImagenesByVarianteId(int varianteId)
    {
        var imagenes = await _unitOfWork.Imagen.GetAllAsync(i => i.VarianteId == varianteId);
        return imagenes;
    }

    public async Task<Imagen> GetImagenById(int imagenId)
    {
        if (imagenId == 0)
            throw new ArgumentNullException(_configuration["Mensajes:E002"]);

        var dbImagen = await _unitOfWork.Imagen.GetByIdAsync(imagenId);

        if (dbImagen == null)
            throw new NullReferenceException(_configuration["Mensajes:E003"]);

        return dbImagen;
    }

    public async Task<Imagen> ToggleActivoById(int imagenId)
    {
        if (imagenId == 0)
            throw new ArgumentNullException(_configuration["Mensajes:E002"]);

        var toggledImagen = await _unitOfWork.Imagen.ToggleActivoById(imagenId);

        if (toggledImagen == null)
            throw new NullReferenceException(_configuration["Mensajes:E003"]);

        await _unitOfWork.SaveAsync();

        return toggledImagen;
    }

    public async Task<Imagen> UpdateImagen(Imagen imagen)
    {
        if (imagen == null)
            throw new ArgumentNullException(_configuration["Mensajes:E001"]);

        if (imagen.Id == 0)
            throw new ArgumentNullException(_configuration["Mensajes:E002"]);

        var updatedImagen = await _unitOfWork.Imagen.UpdateAsync(imagen);

        if (updatedImagen == null)
            throw new NullReferenceException(_configuration["Mensajes:E003"]);

        await _unitOfWork.SaveAsync();

        return updatedImagen;
    }
}
