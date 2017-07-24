using System;
using Microsoft.Extensions.DependencyInjection;

namespace Bib.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterAutoMapping(this IServiceCollection services)
        {
            services = Bib.Services.Configure.ConfigureMapping(services);
            return services;
        }

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            // TODO: Add Business mapping here.
            
            return services;
        }
    }
}