﻿using System;
using FoodAPICore.DatabaseContext;
using FoodAPICore.Dtos;
using FoodAPICore.Models;
using FoodAPICore.Repositories;
using FoodAPICore.Repositories.Food;
using FoodAPICore.Repositories.FoodEfCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FoodAPICore
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            //services.AddSingleton<IFoodRepository, FoodRepository>();
            services.AddScoped<IFoodRepository, FoodEfCoreRepository>();

            //var connection = @"Server=.\SQLEXPRESS;Database=AspNetCoreWorkshop;Trusted_Connection=True;";
            var configurationSection = Configuration.GetSection("ConnectionStrings:DefaultConnection");

            string s = Configuration["ConnectionStrings:DefaultConnection"];

            services.AddDbContext<FoodDbContext>(options => options.UseSqlServer(configurationSection.Value));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAllOrigins");
            AutoMapper.Mapper.Initialize(mapper =>
            {
                mapper.CreateMap<FoodItem, FoodItemDto>().ReverseMap();
            });

            app.UseMvc();
        }
    }
}
