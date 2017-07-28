using AutoMapper;
using Bib.Domain.Model;
using Bib.Services.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.Contracts;
using System.Reflection;

namespace Bib.Services
{
    public class Configure
    {
        public static IServiceCollection ConfigureMapping(IServiceCollection services)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfiles(typeof(Configure).GetTypeInfo().Assembly);
            });
            services.AddSingleton<IMapper, Mapper>(m => new Mapper(Mapper.Configuration));
            
            return services;
        }
    }
}