using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tiendax.Core.DTOs.Colores;
using Tiendax.Core.Entities;
using Tiendax.Core.Models;
using Tiendax.Core.Services;

namespace Tiendax.Api.Controllers;

[ApiController]
[Route("api/color")]
public class ColorController : ControllerBase
{
    private readonly IColorServices _colorServices;
    private readonly IMapper _mapper;

    public ColorController(
        IColorServices colorServices,
        IMapper mapper)
    {
        _colorServices = colorServices;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<ResponseModel<IEnumerable<ColorMantDetail>>>> GetAllActiveColores()
    {
        var response = new ResponseModel<IEnumerable<ColorMantDetail>>();
        try
        {
            var colores = await _colorServices.GetAllActiveColores();
            response.Result = _mapper.Map<IEnumerable<ColorMantDetail>>(colores);

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
    public async Task<ActionResult<ResponseModel<ColorMantDetail>>> GetColorById(int id)
    {
        var response = new ResponseModel<ColorMantDetail>();
        try
        {
            var color = await _colorServices.GetColorById(id);
            response.Result = _mapper.Map<ColorMantDetail>(color);

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
    public async Task<ActionResult<ResponseModel<ColorMantDetail>>> AddColor([FromBody] ColorMantAdd colorMantAdd)
    {
        var response = new ResponseModel<ColorMantDetail>();
        try
        {
            var color = _mapper.Map<Color>(colorMantAdd);
            var addedColor = await _colorServices.AddColor(color);
            response.Result = _mapper.Map<ColorMantDetail>(addedColor);

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
    public async Task<ActionResult<ResponseModel<ColorMantDetail>>> UpdateColor([FromBody] ColorMantUpdate colorMantUpdate)
    {
        var response = new ResponseModel<ColorMantDetail>();
        try
        {
            var color = _mapper.Map<Color>(colorMantUpdate);
            var updatedColor = await _colorServices.UpdateColor(color);
            response.Result = _mapper.Map<ColorMantDetail>(updatedColor);

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
    public async Task<ActionResult<ResponseModel<ColorMantDetail>>> ToggleColorById(int id)
    {
        var response = new ResponseModel<ColorMantDetail>();
        try
        {
            var color = await _colorServices.ToggleActivoById(id);
            response.Result = _mapper.Map<ColorMantDetail>(color);

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
