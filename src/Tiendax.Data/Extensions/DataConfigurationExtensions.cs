using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendax.Data;

namespace System;

public static class DataConfigurationExtensions
{
    public static IServiceCollection AddDataConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TiendaxContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("TiendaxConnection"));
        });

        return services;
    }
}
