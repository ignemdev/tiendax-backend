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

public class CategoriaServices : ICategoriaServices
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IConfiguration _configuration;
    public CategoriaServices(
        IConfiguration configuration,
        IUnitOfWork unitOfWork)
    {
        _configuration = configuration;
        _unitOfWork = unitOfWork;
    }
    public async Task<Categoria> AddCategoria(Categoria categoria)
    {
        if (categoria == null)
            throw new ArgumentNullException(_configuration["Mensajes:E001"]);

        var addedCategoria = await _unitOfWork.Categoria.AddAsync(categoria);
        await _unitOfWork.SaveAsync();

        return addedCategoria;
    }

    public async Task<IEnumerable<Categoria>> GetAllCategorias()
    {
        var categorias = await _unitOfWork.Categoria.GetAllAsync();
        return categorias;
    }

    public async Task<Categoria> GetCategoriaById(int categoriaId)
    {
        if (categoriaId == 0)
            throw new ArgumentNullException(_configuration["Mensajes:E002"]);

        var dbCategoria = await _unitOfWork.Categoria.GetByIdAsync(categoriaId);

        if (dbCategoria == null)
            throw new NullReferenceException(_configuration["Mensajes:E003"]);

        return dbCategoria;
    }

    public async Task<Categoria> ToggleActivoById(int categoriaId)
    {
        if (categoriaId == 0)
            throw new ArgumentNullException(_configuration["Mensajes:E002"]);

        var toggledCategoria = await _unitOfWork.Categoria.ToggleActivoById(categoriaId);

        if (toggledCategoria == null)
            throw new NullReferenceException(_configuration["Mensajes:E003"]);

        await _unitOfWork.SaveAsync();

        return toggledCategoria;
    }

    public async Task<Categoria> UpdateCategoria(Categoria categoria)
    {
        if (categoria == null)
            throw new ArgumentNullException(_configuration["Mensajes:E001"]);

        if (categoria.Id == 0)
            throw new ArgumentNullException(_configuration["Mensajes:E002"]);

        var updatedCategoria = await _unitOfWork.Categoria.UpdateAsync(categoria);

        if (updatedCategoria == null)
            throw new NullReferenceException(_configuration["Mensajes:E003"]);

        await _unitOfWork.SaveAsync();

        return updatedCategoria;
    }
}
