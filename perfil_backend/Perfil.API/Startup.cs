using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Perfil.Core.AutoMapper;
using Perfil.Core.Interfaces;
using Perfil.Core.Services;
using Perfil.Infrastructure.DB.SQL.Data;
using Perfil.Infrastructure.Interface;
using Perfil.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Perfil.API
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

            #region ' Application Services '     
            /*Services cadastrados*/
            services.AddScoped<IEventosService, EventosService>();

            /*Repositórios padrões do Framework para SQL*/
            services.AddScoped<IEventosRepository, DapperEventosRepository>();
            #endregion

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Perfil.API", Version = "v1" });
            });

            #region 'Configuração Dapper SQLServer'
            services.Configure<Settings>(options =>
            {
                options.Environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                //Verify the environment. In case of production, the connection string will be get from environment variable
                if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").Equals("Production") || Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").Equals("Staging"))
                {
                    options.SQLServerConnectionString = Environment.GetEnvironmentVariable("SQL_SERVER_CONNECTIONSTRING");
                }
                else
                {
                    options.SQLServerConnectionString = Configuration.GetSection("ConnectionStrings:SqlServer").Value;
                }
            });
            #endregion

            #region ' AutoMapper '
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Perfil.API v1"));
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
