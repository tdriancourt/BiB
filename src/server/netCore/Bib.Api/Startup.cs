using Bib.Data;
using Bib.Domain;
using Bib.Domain.Model;
using Bib.Domain.Repositories;
using Bib.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Reflection;

namespace Bib.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<BibContext>(options => options.UseSqlite(Configuration.GetConnectionString("sqlitedb")));
            
            // Security Token
            // services.UseJwtBearerAuthentication(new JwtBearerOptions()
            // {
            //     Audience = "http://localhost:5001/", 
            //     Authority = "http://localhost:5000/", 
            //     AutomaticAuthenticate = true
            // });

            services.AddCors(options => {
                options.AddPolicy("AllowAngularClient", builder => builder.WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod());
            });

            Bib.Services.Configure.ConfigureMapping(services);

            // Data Layer
            services.AddScoped<IAclRepository, AclRepository>();
            services.AddScoped<IBorrowRepository, BorrowRepository>();
            services.AddScoped<IMediaTypeRepository, MediaTypeRepository>();
            services.AddScoped<IMediumRepository, MediumRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserGroupRepository, UserGroupRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            // Service Layer
            services.AddTransient<IAclService, AclService>();
            services.AddTransient<IBorrowService, BorrowService>();
            services.AddTransient<IMediaTypeService, MediaTypeService>();
            services.AddTransient<IMediumService, MediumService>();
            services.AddTransient<IUserGroupService, UserGroupService>();
            services.AddTransient<IUserService, UserService>();
            
            // Presentation Layer
            services.AddSingleton<IAssetFileProvider>(new AssetFileProvider(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "assets")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseCors("AllowAngularClient");
            app.UseMvc();
        }
    }
}
