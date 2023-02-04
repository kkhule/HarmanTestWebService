using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Converters;
using ServiceLayer.Interfaces;
using ServiceLayer.Services;

namespace TestProject
{
    public class Startup
    {
        private readonly string CorsPolicyName = "AllowCORS";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();



            services.AddCors(option => option.AddPolicy(CorsPolicyName, builder =>
              builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().Build()
                           ));

            services.AddControllers();

            services.AddControllers().AddNewtonsoftJson(options =>
                        {
                            options.SerializerSettings.Converters.Add(new StringEnumConverter());
        }
                ); 

               //services.AddJsonOptions(options =>
               // {
               //         options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
               //     //options.JsonSerializerOptions.Converters.Add(new jsonni());
               //     //options.JsonSerializerOptions.Converters.Add(new Intto());
               // });


            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddTransient<IProductService, ProductService>();

            services.AddSwaggerGen(
                c =>
                {
                    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Version = "v1",
                        Title = "TestProject.API",
                        Description = "TestProject API",
                    });

                }
                );
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
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "TestProject.API v1");
                }

                    );
            }
            app.UseCors(CorsPolicyName);
            ///app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
