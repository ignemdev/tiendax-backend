using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendax.Core.Services;
using Tiendax.Services;

namespace System;

public static class ServicesRegistrationExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<ICaracteristicaServices, CaracteristicaServices>();
        services.AddTransient<IMarcaServices, MarcaServices>();
        services.AddTransient<ICategoriaServices, CategoriaServices>();
        services.AddTransient<IColorServices, ColorServices>();

        return services;
    }
}
