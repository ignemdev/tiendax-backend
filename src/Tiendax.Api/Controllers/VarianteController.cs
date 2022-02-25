using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tiendax.Core.DTOs.Imagenes;
using Tiendax.Core.DTOs.Variantes;
using Tiendax.Core.Entities;
using Tiendax.Core.Models;
using Tiendax.Core.Services;

namespace Tiendax.Api.Controllers;

[ApiController]
[Route("api/variante")]
public class VarianteController : ControllerBase
{
    private readonly IVarianteServices _varianteServices;
    private readonly IImagenServices _imagenServices;
    private readonly IMapper _mapper;

    public VarianteController(
        IVarianteServices varianteServices,
        IMapper mapper, 
        IImagenServices imagenServices)
    {
        _varianteServices = varianteServices;
        _mapper = mapper;
        _imagenServices = imagenServices;
    }

    [HttpGet]
    public async Task<ActionResult<ResponseModel<IEnumerable<VarianteMantDetail>>>> GetAllVariantes()
    {
        var response = new ResponseModel<IEnumerable<VarianteMantDetail>>();
        try
        {
            var variantes = await _varianteServices.GetAllVariantes();
            response.Data = _mapper.Map<IEnumerable<VarianteMantDetail>>(variantes);

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
    public async Task<ActionResult<ResponseModel<VarianteMantDetail>>> GetVarianteById(int id)
    {
        var response = new ResponseModel<VarianteMantDetail>();
        try
        {
            var variante = await _varianteServices.GetVarianteById(id);
            response.Data = _mapper.Map<VarianteMantDetail>(variante);

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
    public async Task<ActionResult<ResponseModel<VarianteMantDetail>>> AddVariante([FromBody] VarianteMantAdd varianteMantAdd)
    {
        var response = new ResponseModel<VarianteMantDetail>();
        try
        {
            var variante = _mapper.Map<Variante>(varianteMantAdd);
            var addedVariante = await _varianteServices.AddVariante(variante);
            response.Data = _mapper.Map<VarianteMantDetail>(addedVariante);

            if (response.Data == null)
                return NotFound();

            return CreatedAtRoute(201, response);
        }
        catch (Exception ex)
        {
            response.SetErrorMessage((ex.InnerException ?? ex).Message);
            return BadRequest(response);
        }
    }

    [HttpPut]
    public async Task<ActionResult<ResponseModel<VarianteMantDetail>>> UpdateVariante([FromBody] VarianteMantUpdate varianteMantUpdate)
    {
        var response = new ResponseModel<VarianteMantDetail>();
        try
        {
            var variante = _mapper.Map<Variante>(varianteMantUpdate);
            var updatedVariante = await _varianteServices.UpdateVariante(variante);
            response.Data = _mapper.Map<VarianteMantDetail>(updatedVariante);

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
    public async Task<ActionResult<ResponseModel<VarianteMantDetail>>> ToggleVarianteById(int id)
    {
        var response = new ResponseModel<VarianteMantDetail>();
        try
        {
            var variante = await _varianteServices.ToggleActivoById(id);
            response.Data = _mapper.Map<VarianteMantDetail>(variante);

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

    [HttpGet("{id:int}/imagenes")]
    public async Task<ActionResult<ResponseModel<IEnumerable<ImagenMantVariante>>>> GetVarianteImagenes(int id)
    {
        var response = new ResponseModel<IEnumerable<ImagenMantVariante>>();
        try
        {
            var variante = await _imagenServices.GetAllImagenesByVarianteId(id);
            response.Data = _mapper.Map<IEnumerable<ImagenMantVariante>>(variante);

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
