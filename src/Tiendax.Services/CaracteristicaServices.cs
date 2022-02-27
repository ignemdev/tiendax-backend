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

public class CaracteristicaServices : ICaracteristicaServices
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IConfiguration _configuration;
    public CaracteristicaServices(
        IConfiguration configuration, 
        IUnitOfWork unitOfWork)
    {
        _configuration = configuration;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Caracteristica>> GetAllCaracteristicas()
    {
        var caracteristicas = await _unitOfWork.Caracteristica.GetAllAsync(orderBy: x => x.OrderByDescending(x => x.Creado));
        return caracteristicas;
    }

    public async Task<Caracteristica> AddCaracteristica(Caracteristica caracteristica)
    {
        var errors = new List<ValidationResult>();
        if (!Validator.TryValidateObject(caracteristica, new ValidationContext(caracteristica), errors, true))
            throw new InvalidOperationException(string.Join(Environment.NewLine, errors.Select(x => x.ErrorMessage)));

        if (caracteristica == null)
            throw new ArgumentNullException(_configuration["Mensajes:E001"]);

        var addedCaracteristica = await _unitOfWork.Caracteristica.AddAsync(caracteristica);
        await _unitOfWork.SaveAsync();

        return addedCaracteristica;
    }

    public async Task<Caracteristica> GetCaracteristicaById(int caracteristicaId)
    {
        if(caracteristicaId == 0)
            throw new ArgumentNullException(_configuration["Mensajes:E002"]);

        var dbCaracteristica = await _unitOfWork.Caracteristica.GetByIdAsync(caracteristicaId);

        if(dbCaracteristica == null)
            throw new NullReferenceException(_configuration["Mensajes:E003"]);

        return dbCaracteristica;
    }

    public async Task<Caracteristica> UpdateCaracteristica(Caracteristica caracteristica)
    {
        if (caracteristica == null)
            throw new ArgumentNullException(_configuration["Mensajes:E001"]);

        if (caracteristica.Id == 0)
            throw new ArgumentNullException(_configuration["Mensajes:E002"]);

        var updatedCaracteristica = await _unitOfWork.Caracteristica.UpdateAsync(caracteristica);

        if (updatedCaracteristica == null)
            throw new NullReferenceException(_configuration["Mensajes:E003"]);

        await _unitOfWork.SaveAsync();

        return updatedCaracteristica;
    }

    public async Task<Caracteristica> ToggleActivoById(int caracteristicaId)
    {
        if (caracteristicaId == 0)
            throw new ArgumentNullException(_configuration["Mensajes:E002"]);

        var toggledCaracteristica = await _unitOfWork.Caracteristica.ToggleActivoById(caracteristicaId);

        if (toggledCaracteristica == null)
            throw new NullReferenceException(_configuration["Mensajes:E003"]);

        await _unitOfWork.SaveAsync();

        return toggledCaracteristica;
    }
}
