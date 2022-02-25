using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tiendax.Core.DTOs.Categorias;
using Tiendax.Core.Entities;
using Tiendax.Core.Models;
using Tiendax.Core.Services;

namespace Tiendax.Api.Controllers;

[ApiController]
[Route("api/categoria")]
public class CategoriaController : ControllerBase
{
    private readonly ICategoriaServices _categoriaServices;
    private readonly IMapper _mapper;

    public CategoriaController(
        ICategoriaServices categoriaServices,
        IMapper mapper)
    {
        _categoriaServices = categoriaServices;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<ResponseModel<IEnumerable<CategoriaMantDetail>>>> GetAllCategorias()
    {
        var response = new ResponseModel<IEnumerable<CategoriaMantDetail>>();
        try
        {
            var categorias = await _categoriaServices.GetAllCategorias();
            response.Result = _mapper.Map<IEnumerable<CategoriaMantDetail>>(categorias);

            if (response.Result == null)
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
    public async Task<ActionResult<ResponseModel<CategoriaMantDetail>>> GetCategoriaById(int id)
    {
        var response = new ResponseModel<CategoriaMantDetail>();
        try
        {
            var categoria = await _categoriaServices.GetCategoriaById(id);
            response.Result = _mapper.Map<CategoriaMantDetail>(categoria);

            if (response.Result == null)
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
    public async Task<ActionResult<ResponseModel<CategoriaMantDetail>>> AddCategoria([FromBody] CategoriaMantAdd categoriaMantAdd)
    {
        var response = new ResponseModel<CategoriaMantDetail>();
        try
        {
            var categoria = _mapper.Map<Categoria>(categoriaMantAdd);
            var addedCategoria = await _categoriaServices.AddCategoria(categoria);
            response.Result = _mapper.Map<CategoriaMantDetail>(addedCategoria);

            if (response.Result == null)
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
    public async Task<ActionResult<ResponseModel<CategoriaMantDetail>>> UpdateCategoria([FromBody] CategoriaMantUpdate categoriaMantUpdate)
    {
        var response = new ResponseModel<CategoriaMantDetail>();
        try
        {
            var categoria = _mapper.Map<Categoria>(categoriaMantUpdate);
            var updatedCategoria = await _categoriaServices.UpdateCategoria(categoria);
            response.Result = _mapper.Map<CategoriaMantDetail>(updatedCategoria);

            if (response.Result == null)
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
    public async Task<ActionResult<ResponseModel<CategoriaMantDetail>>> ToggleCategoriaById(int id)
    {
        var response = new ResponseModel<CategoriaMantDetail>();
        try
        {
            var categoria = await _categoriaServices.ToggleActivoById(id);
            response.Result = _mapper.Map<CategoriaMantDetail>(categoria);

            if (response.Result == null)
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
