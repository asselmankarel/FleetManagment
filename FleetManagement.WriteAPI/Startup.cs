using FleetManagement.BL.Components;
using FleetManagement.DAL.DataAccess;
using FleetManagement.DAL.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace FleetManagement.WriteAPI
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
            services.AddCors(options => options.AddPolicy(name: "LocalOrigins", builder => {
                builder.WithOrigins("http://localhost:3000")
               .AllowAnyMethod()
               .AllowAnyHeader();
            }));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FleetManagement.WriteAPI", Version = "v1" });
            });
            services.AddMediatR(typeof(Startup));

            services.AddScoped<ApplicationDbContext>();
            services.AddScoped<IRequestRepository, RequestRepository>();
            services.AddScoped<IRequestComponent, RequestComponent>();

            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IVehicleComponent, VehicleComponent>();

            services.AddScoped<IDriverRepository, DriverRepository>();
            services.AddScoped<IDriverComponent, DriverComponent>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FleetManagement.WriteAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("LocalOrigins");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
