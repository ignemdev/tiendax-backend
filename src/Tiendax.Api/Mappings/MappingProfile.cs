using AutoMapper;
using Tiendax.Core.DTOs.Caracteristicas;
using Tiendax.Core.Entities;

namespace Tiendax.Api.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CaracteristicaMantAdd, Caracteristica>();
        CreateMap<CaracteristicaMantUpdate, Caracteristica>();

        CreateMap<Caracteristica, CaracteristicaMantDetail>();
    }
}
