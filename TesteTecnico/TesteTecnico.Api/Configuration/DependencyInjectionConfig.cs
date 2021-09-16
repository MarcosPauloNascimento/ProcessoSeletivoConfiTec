using Microsoft.Extensions.DependencyInjection;
using System;
using TesteTecnico.Infrastructure.CrossCutting.Ioc;

namespace TesteTecnico.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjectionSetup(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            NativeInjectorBootStrapper.RegisterServices(services);

            return services;
        }
    }
}
