using AutoMapper;
using Tiendax.Core.DTOs.Caracteristicas;
using Tiendax.Core.DTOs.Categorias;
using Tiendax.Core.DTOs.Colores;
using Tiendax.Core.DTOs.Imagenes;
using Tiendax.Core.DTOs.Marcas;
using Tiendax.Core.DTOs.Productos;
using Tiendax.Core.DTOs.Variantes;
using Tiendax.Core.Entities;

namespace Tiendax.Api.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CaracteristicaMantAdd, Caracteristica>();
        CreateMap<CaracteristicaMantUpdate, Caracteristica>();
        CreateMap<Caracteristica, CaracteristicaMantDetail>();

        CreateMap<MarcaMantAdd, Marca>();
        CreateMap<MarcaMantUpdate, Marca>();
        CreateMap<Marca, MarcaMantDetail>();
        CreateMap<Marca, MarcaMantProducto>();

        CreateMap<CategoriaMantAdd, Categoria>();
        CreateMap<CategoriaMantUpdate, Categoria>();
        CreateMap<Categoria, CategoriaMantDetail>();
        CreateMap<Categoria, CategoriaMantProducto>();

        CreateMap<ColorMantAdd, Color>();
        CreateMap<ColorMantUpdate, Color>();
        CreateMap<Color, ColorMantDetail>();
        CreateMap<Color, ColorMantVariante>();

        CreateMap<ProductoMantAdd, Producto>();
        CreateMap<ProductoMantUpdate, Producto>();
        CreateMap<Producto, ProductoMantDetail>();

        CreateMap<Imagen, ImagenMantVariante>();

        CreateMap<VarianteMantAdd, Variante>();
        CreateMap<VarianteMantUpdate, Variante>();
        CreateMap<Variante, VarianteMantDetail>();
    }
}
