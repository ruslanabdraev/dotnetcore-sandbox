using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using DataAccessLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AutoMapper;

namespace WebApi
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
            services.AddDabaseContext(Configuration)
                .AddMapper()
                .AddBusinessLayer();
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

    public static class Extensions
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            return services.AddAutoMapper(mapperConfig => mapperConfig.AddProfile<AppMappingProfile>(), assemblies);
        }

        public static IServiceCollection AddDabaseContext(this IServiceCollection services, IConfiguration config)
        {
            var connection = config.GetConnectionString("DatabaseContext");

            services.AddDbContext<TaskContext>((optionsBuilder) =>
            {
                optionsBuilder.UseSqlServer(connection);
            });

            return services;
        }

        public static IServiceCollection AddBusinessLayer(this IServiceCollection services)
        {
            return services.AddScoped<ITaskService, TaskService>();
        }
    }
}
