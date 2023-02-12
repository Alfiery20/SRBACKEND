using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CEN.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace APIService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddControllers();
            services.AddSwaggerGen(
                c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "APIService", Version = "V1" })
            );
            services.AddCors();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "APIService v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(
            options => options
                //.WithOrigins("http://tu-casa-ahora.s3-website-us-east-1.amazonaws.com","http://localhost:8080")
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()

            );
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            Configuration = new ConfigurationBuilder()
             //.AddJsonFile("appsettings.json")

             //.SetBasePath("/app")
             .SetBasePath(Directory.GetCurrentDirectory())
             //.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("appsettings")}.json")
             .AddJsonFile($"appsettings.Development.json")
             .AddEnvironmentVariables()
             .Build();

            Constants.server_name = this.Configuration.GetValue<String>("SQLConexion:server_name");
            Constants.database_name = this.Configuration.GetValue<String>("SQLConexion:database_name");
            Constants.user_name = this.Configuration.GetValue<String>("SQLConexion:user_name");
            Constants.user_pass = this.Configuration.GetValue<String>("SQLConexion:user_pass");
            Constants.cadena_conexion = $"data source = {Constants.server_name}; initial catalog = {Constants.database_name}; user id = {Constants.user_name}; password = {Constants.user_pass}; TrustServerCertificate=True";
        }
    }
}