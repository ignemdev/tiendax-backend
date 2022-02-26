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

public class VarianteServices : IVarianteServices
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IConfiguration _configuration;
    public VarianteServices(
        IConfiguration configuration,
        IUnitOfWork unitOfWork)
    {
        _configuration = configuration;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Variante>> GetAllVariantes()
    {
        var variantes = await _unitOfWork.Variante.GetAllAsync(v => v.Color!.Activo == Convert.ToBoolean((int)Estado.Activo), 
            includeProperties: "Color");
        return variantes;
    }

    public async Task<Variante> AddVariante(Variante variante)
    {
        var errors = new List<ValidationResult>();
        if (!Validator.TryValidateObject(variante, new ValidationContext(variante), errors, true))
            throw new InvalidOperationException(string.Join(Environment.NewLine, errors.Select(x => x.ErrorMessage)));

        if (variante == null)
            throw new ArgumentNullException(_configuration["Mensajes:E001"]);

        var addedVariante = await _unitOfWork.Variante.AddAsync(variante);
        await _unitOfWork.SaveAsync();

        return addedVariante;
    }

    public async Task<Variante> GetVarianteById(int varianteId)
    {
        if (varianteId == 0)
            throw new ArgumentNullException(_configuration["Mensajes:E002"]);

        var dbVariante = await _unitOfWork.Variante.GetFirstOrDefaultAsync(v => v.Id == varianteId, includeProperties: "Color");

        if (dbVariante == null)
            throw new NullReferenceException(_configuration["Mensajes:E003"]);

        return dbVariante;
    }

    public async Task<Variante> UpdateVariante(Variante variante)
    {
        if (variante == null)
            throw new ArgumentNullException(_configuration["Mensajes:E001"]);

        if (variante.Id == 0)
            throw new ArgumentNullException(_configuration["Mensajes:E002"]);

        var updatedVariante = await _unitOfWork.Variante.UpdateAsync(variante);

        if (updatedVariante == null)
            throw new NullReferenceException(_configuration["Mensajes:E003"]);

        await _unitOfWork.SaveAsync();

        return updatedVariante;
    }

    public async Task<Variante> ToggleActivoById(int varianteId)
    {
        if (varianteId == 0)
            throw new ArgumentNullException(_configuration["Mensajes:E002"]);

        var toggledVariante = await _unitOfWork.Variante.ToggleActivoById(varianteId);

        if (toggledVariante == null)
            throw new NullReferenceException(_configuration["Mensajes:E003"]);

        await _unitOfWork.SaveAsync();

        return toggledVariante;
    }
}
