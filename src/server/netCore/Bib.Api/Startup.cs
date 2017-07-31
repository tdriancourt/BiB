using Bib.Data;
using Bib.Domain;
using Bib.Domain.Model;
using Bib.Domain.Repositories;
using Bib.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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
            services.AddDbContext<BibContext>(options => options.UseSqlite(@"DataSource=C:\Workspaces\BiB\data\bib.db"));
            // services.UseJwtBearerAuthentication(new JwtBearerOptions()
            // {
            //     Audience = "http://localhost:5001/", 
            //     Authority = "http://localhost:5000/", 
            //     AutomaticAuthenticate = true
            // });
            Bib.Services.Configure.ConfigureMapping(services);
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IAclRepository, AclRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseMvc();
        }
    }
}
