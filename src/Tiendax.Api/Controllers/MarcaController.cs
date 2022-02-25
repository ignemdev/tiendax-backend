using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tiendax.Core.DTOs.Marcas;
using Tiendax.Core.Entities;
using Tiendax.Core.Models;
using Tiendax.Core.Services;

namespace Tiendax.Api.Controllers;

[ApiController]
[Route("api/marca")]
public class MarcaController : ControllerBase
{
    private readonly IMarcaServices _marcaServices;
    private readonly IMapper _mapper;

    public MarcaController(
        IMarcaServices marcaServices, 
        IMapper mapper)
    {
        _marcaServices = marcaServices;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<ResponseModel<IEnumerable<MarcaMantDetail>>>> GetAllMarcas()
    {
        var response = new ResponseModel<IEnumerable<MarcaMantDetail>>();
        try
        {
            var marcas = await _marcaServices.GetAllMarcas();
            response.Data = _mapper.Map<IEnumerable<MarcaMantDetail>>(marcas);

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
    public async Task<ActionResult<ResponseModel<MarcaMantDetail>>> GetMarcaById(int id)
    {
        var response = new ResponseModel<MarcaMantDetail>();
        try
        {
            var caracteristica = await _marcaServices.GetMarcaById(id);
            response.Data = _mapper.Map<MarcaMantDetail>(caracteristica);

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
    public async Task<ActionResult<ResponseModel<MarcaMantDetail>>> AddMarca([FromBody] MarcaMantAdd marcaMantAdd)
    {
        var response = new ResponseModel<MarcaMantDetail>();
        try
        {
            var marca = _mapper.Map<Marca>(marcaMantAdd);
            var addedMarca = await _marcaServices.AddMarca(marca);
            response.Data = _mapper.Map<MarcaMantDetail>(addedMarca);

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
    public async Task<ActionResult<ResponseModel<MarcaMantDetail>>> UpdateMarca([FromBody] MarcaMantUpdate marcaMantUpdate)
    {
        var response = new ResponseModel<MarcaMantDetail>();
        try
        {
            var marca = _mapper.Map<Marca>(marcaMantUpdate);
            var updatedMarca = await _marcaServices.UpdateMarca(marca);
            response.Data = _mapper.Map<MarcaMantDetail>(updatedMarca);

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
    public async Task<ActionResult<ResponseModel<MarcaMantDetail>>> ToggleMarcaById(int id)
    {
        var response = new ResponseModel<MarcaMantDetail>();
        try
        {
            var marca = await _marcaServices.ToggleActivoById(id);
            response.Data = _mapper.Map<MarcaMantDetail>(marca);

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
