using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendax.Core;
using Tiendax.Core.Entities;
using Tiendax.Core.Enumerables;
using Tiendax.Core.Services;

namespace Tiendax.Services;

public class MarcaServices : IMarcaServices
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IConfiguration _configuration;

    public MarcaServices(
        IUnitOfWork unitOfWork, 
        IConfiguration configuration
        )
    {
        _unitOfWork = unitOfWork;
        _configuration = configuration;
    }

    public async Task<Marca> AddMarca(Marca marca)
    {
        if (marca == null)
            throw new ArgumentNullException(_configuration["Mensajes:E001"]);

        var addedMarca = await _unitOfWork.Marca.AddAsync(marca);
        await _unitOfWork.SaveAsync();

        return addedMarca;
    }

    public async Task<IEnumerable<Marca>> GetAllMarcas()
    {
        var marcas = await _unitOfWork.Marca.GetAllAsync(c => c.Activo == Convert.ToBoolean((int)Estado.Activo));
        return marcas;
    }

    public async Task<Marca> GetMarcaById(int marcaId)
    {
        if (marcaId == 0)
            throw new ArgumentNullException(_configuration["Mensajes:E002"]);

        var dbMarca = await _unitOfWork.Marca.GetByIdAsync(marcaId);

        if (dbMarca == null)
            throw new NullReferenceException(_configuration["Mensajes:E003"]);

        return dbMarca;
    }

    public async Task<Marca> ToggleActivoById(int marcaId)
    {
        if (marcaId == 0)
            throw new ArgumentNullException(_configuration["Mensajes:E002"]);

        var toggledMarca = await _unitOfWork.Marca.ToggleActivoById(marcaId);

        if (toggledMarca == null)
            throw new NullReferenceException(_configuration["Mensajes:E003"]);

        if (toggledMarca.Productos.Any())
        {
            toggledMarca.Productos.ToList().ForEach(p => p.Activo = toggledMarca.Activo);
        }

        await _unitOfWork.SaveAsync();

        return toggledMarca;
    }

    public async Task<Marca> UpdateMarca(Marca marca)
    {
        if (marca == null)
            throw new ArgumentNullException(_configuration["Mensajes:E001"]);

        if (marca.Id == 0)
            throw new ArgumentNullException(_configuration["Mensajes:E002"]);

        var updatedMarca = await _unitOfWork.Marca.UpdateAsync(marca);

        if (updatedMarca == null)
            throw new NullReferenceException(_configuration["Mensajes:E003"]);

        await _unitOfWork.SaveAsync();

        return updatedMarca;
    }
}
