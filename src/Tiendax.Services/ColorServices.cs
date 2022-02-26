using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendax.Core;
using Tiendax.Core.Entities;
using Tiendax.Core.Enumerables;
using Tiendax.Core.Services;

namespace Tiendax.Services;

public class ColorServices : IColorServices
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IConfiguration _configuration;
    public ColorServices(
        IConfiguration configuration,
        IUnitOfWork unitOfWork)
    {
        _configuration = configuration;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Color>> GetAllColores()
    {
        var colors = await _unitOfWork.Color.GetAllAsync();
        return colors;
    }

    public async Task<Color> AddColor(Color color)
    {
        var errors = new List<ValidationResult>();
        if (!Validator.TryValidateObject(color, new ValidationContext(color), errors, true))
            throw new InvalidOperationException(string.Join(Environment.NewLine, errors.Select(x => x.ErrorMessage)));

        if (color == null)
            throw new ArgumentNullException(_configuration["Mensajes:E001"]);

        var addedColor = await _unitOfWork.Color.AddAsync(color);
        await _unitOfWork.SaveAsync();

        return addedColor;
    }

    public async Task<Color> GetColorById(int colorId)
    {
        if (colorId == 0)
            throw new ArgumentNullException(_configuration["Mensajes:E002"]);

        var dbColor = await _unitOfWork.Color.GetByIdAsync(colorId);

        if (dbColor == null)
            throw new NullReferenceException(_configuration["Mensajes:E003"]);

        return dbColor;
    }

    public async Task<Color> UpdateColor(Color color)
    {
        if (color == null)
            throw new ArgumentNullException(_configuration["Mensajes:E001"]);

        if (color.Id == 0)
            throw new ArgumentNullException(_configuration["Mensajes:E002"]);

        var updatedColor = await _unitOfWork.Color.UpdateAsync(color);

        if (updatedColor == null)
            throw new NullReferenceException(_configuration["Mensajes:E003"]);

        await _unitOfWork.SaveAsync();

        return updatedColor;
    }

    public async Task<Color> ToggleActivoById(int colorId)
    {
        if (colorId == 0)
            throw new ArgumentNullException(_configuration["Mensajes:E002"]);

        var toggledColor = await _unitOfWork.Color.ToggleActivoById(colorId);

        if (toggledColor == null)
            throw new NullReferenceException(_configuration["Mensajes:E003"]);

        await _unitOfWork.SaveAsync();

        return toggledColor;
    }
}
