using Compugraf.Application.MappingProfile;
using Compugraf.Application.Service;
using Compugraf.Domain.Repository;
using Compugraf.Infrastructure.Context;
using Compugraf.Infrastructure.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

[assembly: ApiController]
namespace Compugraf.Api
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
            services.AddControllers();

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Compugraf - Pessoas" }));

            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            });

            services.AddAutoMapper(typeof(PersonProfile));

            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IPersonService, PersonService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(config =>
            {
                config.AllowAnyOrigin();
                config.AllowAnyMethod();
                config.AllowAnyHeader();
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Compugraf - Pessoas");
            });

            var applicationContext = serviceProvider.GetService<DatabaseContext>();
            applicationContext.Database.Migrate();
        }
    }
}
