using HospitalManagement.Core.Repositories;
using HospitalManagement.Core.Service;
using HospitalManagement.Core.UnitOfWorks;
using HospitalManagement.Repository.Repositories;
using HospitalManagement.Repository.UnitOfWorks;
using HospitalManagement.Repository;
using HospitalManagement.Service.Mapping;
using HospitalManagement.Service.Services;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HospitalManagement;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container
    public void ConfigureServices(IServiceCollection services)
    {
        var builder = WebApplication.CreateBuilder();
        services.AddControllers();
        services.AddSwaggerGen(h =>
        {
            h.SwaggerDoc("v1", new OpenApiInfo { Title = "HospitalManagement", Version = "v1" });
        });

       services.AddScoped<IUnitOfWork, UnitOfWork>();
       services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
       services.AddScoped(typeof(IService<>), typeof(Service<>));
       services.AddAutoMapper(typeof(MapProfile));
       services.AddScoped<IProductRepository, ProductRepository>();
       services.AddScoped<IProductService, ProductService>();

       services.AddScoped<IRoomRepository, RoomRepository>();
       services.AddScoped<IRoomService, RoomService>();

       services.AddScoped<IWarehouseRepository, WarehouseRepository>();
       services.AddScoped<IWarehouseService, WarehouseService>();


        services.AddDbContext<AppDbContext>(x =>
         {
             x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
             {
                 option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
             });
         });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        app.UseSwagger();
        app.UseSwaggerUI(h => h.SwaggerEndpoint("./v1/swagger.json", "HospitalManagement v1"));
        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("Welcome to running ASP.NET Core on AWS Lambda");
            });
        });
    }
}