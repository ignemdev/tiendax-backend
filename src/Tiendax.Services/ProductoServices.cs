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
using Tiendax.Core.Models;
using Tiendax.Core.Services;

namespace Tiendax.Services;

public class ProductoServices : IProductoServices
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IConfiguration _configuration;
    public ProductoServices(
        IConfiguration configuration,
        IUnitOfWork unitOfWork)
    {
        _configuration = configuration;
        _unitOfWork = unitOfWork;
    }
    public async Task<Producto> AddProducto(Producto producto)
    {
        var errors = new List<ValidationResult>();
        if (!Validator.TryValidateObject(producto, new ValidationContext(producto), errors, true))
            throw new InvalidOperationException(string.Join(Environment.NewLine, errors.Select(x => x.ErrorMessage)));

        if (producto == null)
            throw new ArgumentNullException(_configuration["Mensajes:E001"]);

        var addedProducto = await _unitOfWork.Producto.AddAsync(producto);
        await _unitOfWork.SaveAsync();

        return addedProducto;
    }

    public async Task<IEnumerable<Producto>> GetAllProductosWithIncludes(ProductosPaginationParams productosPaginationParams)
    {
        var productos = await _unitOfWork.Producto.GetAllWithActiveCategorias(productosPaginationParams);

        //mandar categorias, marca, nombre
        //a traves de id en front obtener variantes (id, color, precio)

        return productos;
    }

    public async Task<Producto> GetProductoById(int productoId)
    {
        if (productoId == 0)
            throw new ArgumentNullException(_configuration["Mensajes:E002"]);

        var dbProducto = await _unitOfWork.Producto
                                    .GetFirstOrDefaultWithActiveCategorias(p => p.Id == productoId);

        if (dbProducto == null)
            throw new NullReferenceException(_configuration["Mensajes:E003"]);
        //a traves de id en front obtener variantes (id, color, precio, fotos), caracteristicas
        return dbProducto;
    }

    public async Task<Producto> UpdateProducto(Producto producto)
    {
        if (producto == null)
            throw new ArgumentNullException(_configuration["Mensajes:E001"]);

        if (producto.Id == 0)
            throw new ArgumentNullException(_configuration["Mensajes:E002"]);

        var updatedProducto = await _unitOfWork.Producto.UpdateAsync(producto);

        if (updatedProducto == null)
            throw new NullReferenceException(_configuration["Mensajes:E003"]);

        await _unitOfWork.SaveAsync();

        return updatedProducto;
    }

    public async Task<Producto> ToggleActivoById(int productoId)
    {
        if (productoId == 0)
            throw new ArgumentNullException(_configuration["Mensajes:E002"]);

        var toggledProducto = await _unitOfWork.Producto.ToggleActivoById(productoId);

        if (toggledProducto == null)
            throw new NullReferenceException(_configuration["Mensajes:E003"]);

        if (toggledProducto.Variantes.Any())
        {
            toggledProducto.Variantes.ToList().ForEach(v => v.Activo = toggledProducto.Activo);
        }

        await _unitOfWork.SaveAsync();

        return toggledProducto;
    }

    public async Task<Producto> AddProductoCategorias(int productoId, IEnumerable<int> categoriasIds)
    {
        if (productoId == 0)
            throw new ArgumentNullException(_configuration["Mensajes:E002"]);

        if (categoriasIds == null || !categoriasIds.Any())
            throw new ArgumentNullException(_configuration["Mensajes:E004"]);

        var productoWithCategorias = await _unitOfWork.Producto.AddCategorias(productoId, categoriasIds);

        if (productoWithCategorias == null)
            throw new NullReferenceException(_configuration["Mensajes:E003"]);

        await _unitOfWork.SaveAsync();

        return productoWithCategorias;
    }
}
