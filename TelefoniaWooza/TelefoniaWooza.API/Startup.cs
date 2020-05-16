using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TelefoniaWooza.Application;
using TelefoniaWooza.Domain.Interfaces.Repositories;
using TelefoniaWooza.Infra.Data.Contexts;
using TelefoniaWooza.Infra.Data.Repositories;

namespace TelefoniaWooza.API
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
            services.AddDbContext<TelefoniaContext>();

            services.AddScoped<PlanoApplication>();



            services.AddScoped<IPlanoRepository,PlanoRepository>();
            services.AddScoped<IDDDRepository,DDDRepository>();
            services.AddScoped<IOperadoraRepository,OperadoraRepository>();
            services.AddScoped<IDDDPlanoRepository,DDDPlanoRepository>();
            services.AddScoped<PlanoApplication>();


            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            }); ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
