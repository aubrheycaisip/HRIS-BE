using HRIS_BE.Helpers.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net;
using System.Reflection;

namespace HRIS_BE
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            RegisterServicesWithAttribute(services);
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<HRISDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseRouting();

            app.UseCors(options => options
                                   .AllowAnyMethod()
                                   .AllowAnyHeader()
                                   .WithOrigins("*")
                                 );

            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var exception = context.Features.Get<IExceptionHandlerFeature>();
                    if (exception != null)
                    {
                        var errorMessage = new
                        {
                            error = "An unexpected error occurred.",
                            details = exception.Error.Message
                        };

                        var jsonError = JsonConvert.SerializeObject(errorMessage);
                        await context.Response.WriteAsync(jsonError).ConfigureAwait(false);
                    }
                });
            });

            app.UseHsts();
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        private static void RegisterServicesWithAttribute(IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var typesWithAttribute = assembly.GetTypes()
                .Where(type => type.IsClass && type.GetCustomAttribute<ServiceDependencyAttribute>() != null);

            foreach (var type in typesWithAttribute)
            {
                var attribute = type.GetCustomAttribute<ServiceDependencyAttribute>();
                if(attribute?.ServiceType != null)
                {
                    services.Add(new ServiceDescriptor(attribute.ServiceType, type, attribute.Lifetime));
                    Console.WriteLine($"Registered service: {type.FullName} and Service Type: {attribute.ServiceType} with lifetime: {attribute.Lifetime}");
                }
                

                
            }
        }
    }
}
