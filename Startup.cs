using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using GoingTo_API.Domain.Persistence.Context;
using GoingTo_API.Domain.Repositories;
using GoingTo_API.Persistence;
using GoingTo_API.Domain.Services;
using GoingTo_API.Services;
using GoingTo_API.Persistence.Repositories;
using Microsoft.OpenApi.Models;
using AutoMapper;
using System.IO;
using System.Reflection;
using Swashbuckle.AspNetCore.Filters;

namespace GoingTo_API
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
            services.AddMvc();

            services.AddControllers();
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<ILocatableRepository, LocatableRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserAchievementRepository, UserAchievementRepository>();
            services.AddScoped<IAchievementRepository, AchievementRepository>();
            services.AddScoped<ICountryRepository,CountryRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IPlaceRepository, PlaceRepository>();
            services.AddScoped<IFavouriteRepository, FavouriteRepository>();
            
            services.AddScoped<ILocatableService, LocatableService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICountryService,CountryService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IPlaceService, PlaceService>();
            services.AddScoped<IFavouriteService, FavouriteService>();
            services.AddScoped<IUserAchievementService, UserAchievementService>();
            services.AddScoped<IAchievementService, AchievementService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(typeof(Startup));


            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GoingTo API", Version = "v1" });
                c.ExampleFilters();
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddSwaggerExamplesFromAssemblyOf<Startup>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "GoingTo API V1");
                c.RoutePrefix = string.Empty;
            });
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
}
