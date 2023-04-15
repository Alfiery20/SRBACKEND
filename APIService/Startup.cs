using CEN.Helpers;
using Microsoft.OpenApi.Models;
using Stripe;

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
                c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "APIService", Version = "V1" });
                    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Description = "Ingrese el token JWT con el prefijo 'Bearer' en el campo. Ejemplo: Bearer {token}",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer"
                    });
                    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new List<String>()
                        }
                    });
                }
            );
            services.AddCors();
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            //{
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuer = false,
            //        ValidIssuer = null,
            //        ValidAudience = null,
            //        ValidateAudience = false,
            //        ValidateLifetime = true,
            //        ValidateIssuerSigningKey = true,
            //        //ValidIssuer = this.Configuration.GetValue<String>("jwt:Issuer"),
            //        //ValidAudience = this.Configuration.GetValue<String>("jwt:Audience"),
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.Configuration.GetValue<String>("jwt:key")))
            //    };
            //});
            //services.AddAuthorization(options =>
            //{
            //    options.DefaultPolicy = new AuthorizationPolicyBuilder()
            //    .RequireAuthenticatedUser()
            //    .Build();
            //});
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
            //STRIPE
            app.UseStaticFiles();
            //STRIPE
            app.UseRouting();
            app.UseCors(
            options => options
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );
            app.UseAuthorization();
            app.UseAuthentication();
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

            Constants.Server_name = this.Configuration.GetValue<String>("SQLConexion:server_name");
            Constants.Database_name = this.Configuration.GetValue<String>("SQLConexion:database_name");
            Constants.User_name = this.Configuration.GetValue<String>("SQLConexion:user_name");
            Constants.User_pass = this.Configuration.GetValue<String>("SQLConexion:user_pass");
            Constants.Cadena_conexion = $"data source = {Constants.Server_name}; initial catalog = {Constants.Database_name}; user id = {Constants.User_name}; password = {Constants.User_pass}; TrustServerCertificate=True";
            Constants.Clave_encriptacion = this.Configuration.GetValue<String>("clave_encriptacion");
            Constants.Cloud = this.Configuration.GetValue<String>("cloudinary:cloud");
            Constants.Api_key = this.Configuration.GetValue<String>("cloudinary:api_key");
            Constants.Api_secret = this.Configuration.GetValue<String>("cloudinary:api_secret");
            Constants.Base_url_cloud = this.Configuration.GetValue<String>("cloudinary:base_url");
            Constants.Dimensions = this.Configuration.GetValue<String>("cloudinary:dimensions");
            Constants.Key = this.Configuration.GetValue<String>("jwt:key");
            Constants.Key = this.Configuration.GetValue<String>("jwt:key");
            Constants.Issuer = this.Configuration.GetValue<String>("jwt:Issuer");
            Constants.Audience = this.Configuration.GetValue<String>("jwt:Audience");
            Constants.Subject = this.Configuration.GetValue<String>("jwt:Subject");
            Constants.Expire = this.Configuration.GetValue<int>("jwt:Expire");
            //STRIPE
            StripeConfiguration.ApiKey = this.Configuration.GetValue<string>("stripe_key");
        }
    }
}