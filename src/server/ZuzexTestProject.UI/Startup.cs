using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ZuzexTestProject.Infrastructure.DTO;
using ZuzexTestProject.Infrastructure.EF;
using ZuzexTestProject.Infrastructure.Services;
using ZuzexTestProject.UI.Middlewares;
using ZuzexTestProject.UI.ViewModels;

namespace ZuzexTestProject.UI
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
            // Entity Framework
            services.AddDbContext<PostsContext>(options => 
                options.UseNpgsql(Configuration.GetConnectionString("DefaultPostgres")));

            // Services
            services.AddTransient<IPostsService, PostService>();

            // Automapper
            services.AddAutoMapper(typeof(MapperProfileVM), typeof(MapperProfileInfrastructure));

            // Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Test Project API", Version = "v1" });
            });

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test Project API V1");
                });
            }

            app.UseRouting();

            app.UseMiddleware<CustomAppErrorCodes>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
