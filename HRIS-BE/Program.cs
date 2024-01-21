using HRIS_BE;
using HRIS_BE.Helpers.Interfaces;
using HRIS_BE.Helpers.Models;
using HRIS_BE.Helpers.Services;
using Microsoft.EntityFrameworkCore;

//var builder = WebApplication.CreateBuilder(args);
//IConfiguration configuration = new ConfigurationBuilder()
//    .SetBasePath(Directory.GetCurrentDirectory())
//    .AddJsonFile("appsettings.json")
//    .Build();

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<HRISDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseCors(options => options
//                       .AllowAnyMethod()
//                       .AllowAnyHeader()
//                       .WithOrigins("*")
//                     );

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();

static IHostBuilder CreateWebHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
   .ConfigureWebHostDefaults(webBuilder =>
   {
       webBuilder.UseContentRoot(Directory.GetCurrentDirectory());
       webBuilder.UseIISIntegration();
       webBuilder.UseStartup<Startup>();
   });

CreateWebHostBuilder(args).Build().Run();
