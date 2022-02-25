using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tiendax.Core.DTOs.Productos;
using Tiendax.Core.Entities;
using Tiendax.Core.Models;
using Tiendax.Core.Services;

namespace Tiendax.Api.Controllers;

[ApiController]
[Route("api/producto")]
public class ProductoController : ControllerBase
{
    private readonly IProductoServices _productoServices;
    private readonly IMapper _mapper;

    public ProductoController(
        IProductoServices productoServices,
        IMapper mapper)
    {
        _productoServices = productoServices;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<ResponsePaginationModel<IEnumerable<ProductoMantDetail>>>> GetAllProductos([FromQuery] ProductosPaginationParams productosPaginationParams)
    {
        var response = new ResponsePaginationModel<IEnumerable<ProductoMantDetail>>();
        try
        {
            var productos = await _productoServices.GetAllProductosWithIncludes(productosPaginationParams);
            response.SetPagination(productos, productosPaginationParams);
            response.Data = _mapper.Map<IEnumerable<ProductoMantDetail>>(productos);

            if (response.Data == null)
                return NotFound();

            return Ok(response);
        }
        catch (Exception ex)
        {
            response.SetErrorMessage((ex.InnerException ?? ex).Message);
            return BadRequest(response);
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ResponseModel<ProductoMantDetail>>> GetProductoById(int id)
    {
        var response = new ResponseModel<ProductoMantDetail>();
        try
        {
            var producto = await _productoServices.GetProductoById(id);
            response.Data = _mapper.Map<ProductoMantDetail>(producto);

            if (response.Data == null)
                return NotFound();

            return Ok(response);
        }
        catch (Exception ex)
        {
            response.SetErrorMessage((ex.InnerException ?? ex).Message);
            return BadRequest(response);
        }
    }

    [HttpPost]
    public async Task<ActionResult<ResponseModel<ProductoMantDetail>>> AddProducto([FromBody] ProductoMantAdd productoMantAdd)
    {
        var response = new ResponseModel<ProductoMantDetail>();
        try
        {
            var producto = _mapper.Map<Producto>(productoMantAdd);
            var addedProducto = await _productoServices.AddProducto(producto);
            response.Data = _mapper.Map<ProductoMantDetail>(addedProducto);

            if (response.Data == null)
                return NotFound();

            return StatusCode(201, response);
        }
        catch (Exception ex)
        {
            response.SetErrorMessage((ex.InnerException ?? ex).Message);
            return BadRequest(response);
        }
    }

    [HttpPut]
    public async Task<ActionResult<ResponseModel<ProductoMantDetail>>> UpdateProducto([FromBody] ProductoMantUpdate productoMantUpdate)
    {
        var response = new ResponseModel<ProductoMantDetail>();
        try
        {
            var producto = _mapper.Map<Producto>(productoMantUpdate);
            var updatedProducto = await _productoServices.UpdateProducto(producto);
            response.Data = _mapper.Map<ProductoMantDetail>(updatedProducto);

            if (response.Data == null)
                return NotFound();

            return Ok(response);
        }
        catch (Exception ex)
        {
            response.SetErrorMessage((ex.InnerException ?? ex).Message);
            return BadRequest(response);
        }
    }

    [HttpGet("{id:int}/toggle")]
    public async Task<ActionResult<ResponseModel<ProductoMantDetail>>> ToggleProductoById(int id)
    {
        var response = new ResponseModel<ProductoMantDetail>();
        try
        {
            var producto = await _productoServices.ToggleActivoById(id);
            response.Data = _mapper.Map<ProductoMantDetail>(producto);

            if (response.Data == null)
                return NotFound();

            return Ok(response);
        }
        catch (Exception ex)
        {
            response.SetErrorMessage((ex.InnerException ?? ex).Message);
            return BadRequest(response);
        }
    }

    [HttpPost("{id:int}/categorias")]
    public async Task<ActionResult<ResponseModel<ProductoMantDetail>>> AddProductoCategorias(int id, [FromBody] IEnumerable<int> categoriasIds)
    {
        var response = new ResponseModel<ProductoMantDetail>();
        try
        {
            var producto = await _productoServices.AddProductoCategorias(id, categoriasIds);
            response.Data = _mapper.Map<ProductoMantDetail>(producto);

            if (response.Data == null)
                return NotFound();

            return Ok(response);
        }
        catch (Exception ex)
        {
            response.SetErrorMessage((ex.InnerException ?? ex).Message);
            return BadRequest(response);
        }
    }
}
