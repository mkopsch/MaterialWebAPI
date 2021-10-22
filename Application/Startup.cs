using MaterialWebAPI.Application.Models;
using MaterialWebAPI.Domain.Entities;
using MaterialWebAPI.Infrastructure.Context;
using MaterialWebAPI.Infrastructure.Persistence;
using MaterialWebAPI.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace MaterialWebAPI.Application
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MaterialWebAPI", Version = "v1" });
            });

            // services.AddSingleton(typeof(IRepository<>), typeof(RavenDbRepository<>));

            services.AddSingleton(typeof(IRepository<Material>), typeof(MockDbRepository));

            // services.AddSingleton<IRavenDbContext, RavenDbContext>();

            services.AddSingleton<IMockDbContext, MockDbContext>();

            services.Configure<PersistenceSettings>(Configuration.GetSection("Database"));

            services.AddSingleton(new AutoMapper.MapperConfiguration(config =>
            {
                config.CreateMap<MaterialModel, Material>();
            }).CreateMapper());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MaterialWebAPI v1");
                    c.RoutePrefix = "";
                }
                );
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
