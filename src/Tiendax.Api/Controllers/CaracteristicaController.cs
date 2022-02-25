using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tiendax.Core.DTOs.Caracteristicas;
using Tiendax.Core.Entities;
using Tiendax.Core.Models;
using Tiendax.Core.Services;
using Tiendax.Data;

namespace Tiendax.Api.Controllers;

[ApiController]
[Route("api/caracteristicas")]
public class CaracteristicaController : ControllerBase
{
    private readonly ICaracteristicaServices _caracteristicaServices;
    private readonly IMapper _mapper;

    public CaracteristicaController(
        ICaracteristicaServices caracteristicaServices,
        IMapper mapper)
    {
        _caracteristicaServices = caracteristicaServices;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<ResponseModel<IEnumerable<CaracteristicaMantDetail>>>> GetAllCaracteristicas()
    {
        var response = new ResponseModel<IEnumerable<CaracteristicaMantDetail>>();
        try
        {
            var caracteristicas = await _caracteristicaServices.GetAllCaracteristicas();
            response.Result = _mapper.Map<IEnumerable<CaracteristicaMantDetail>>(caracteristicas);

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
    public async Task<ActionResult<ResponseModel<CaracteristicaMantDetail>>> GetCaracteristicaById(int id)
    {
        var response = new ResponseModel<CaracteristicaMantDetail>();
        try
        {
            var caracteristica = await _caracteristicaServices.GetCaracteristicaById(id);
            response.Result = _mapper.Map<CaracteristicaMantDetail>(caracteristica);

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
    public async Task<ActionResult<ResponseModel<CaracteristicaMantDetail>>> AddCaracteristica([FromBody] CaracteristicaMantAdd caracteristicaMantAdd)
    {
        var response = new ResponseModel<CaracteristicaMantDetail>();
        try
        {
            var caracteristica = _mapper.Map<Caracteristica>(caracteristicaMantAdd);
            var addedCaracteristica = await _caracteristicaServices.AddCaracteristica(caracteristica);
            response.Result = _mapper.Map<CaracteristicaMantDetail>(addedCaracteristica);

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
    public async Task<ActionResult<ResponseModel<CaracteristicaMantDetail>>> UpdateCaracteristica([FromBody] CaracteristicaMantUpdate caracteristicaMantUpdate)
    {
        var response = new ResponseModel<CaracteristicaMantDetail>();
        try
        {
            var caracteristica = _mapper.Map<Caracteristica>(caracteristicaMantUpdate);
            var updatedCaracteristica = await _caracteristicaServices.UpdateCaracteristica(caracteristica);
            response.Result = _mapper.Map<CaracteristicaMantDetail>(updatedCaracteristica);

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
    public async Task<ActionResult<ResponseModel<CaracteristicaMantDetail>>> ToggleCaracteristicaById(int id)
    {
        var response = new ResponseModel<CaracteristicaMantDetail>();
        try
        {
            var caracteristica = await _caracteristicaServices.ToggleActivoById(id);
            response.Result = _mapper.Map<CaracteristicaMantDetail>(caracteristica);

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
