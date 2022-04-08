using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PassengerMicroservice.AppServices;
using PassengerMicroservice.Core.Entity;
using PassengerMicroservice.EntityFramework;
using PassengerMicroservice.EntityFramework.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace PassengerMicroservice.Api
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

            //Database Connection
            string connectionStrig = Configuration.GetConnectionString("Default");
            services.AddDbContext<PassengerContext>(options=>
            options.UseInMemoryDatabase(databaseName: "passengerMemory"));
           // options.UseMySql(connectionStrig, ServerVersion.AutoDetect(connectionStrig)));

            services.AddTransient<IPassengerAppServices, PassengerAppServices>();
            
            //Repository

            services.AddTransient<IRepository<int, PassengerMicroservice.Core.Entity.Passenger>, PassengerRepository>();

            //AutoMapper
            services.AddAutoMapper(typeof(PassengerMicroservice.AppServices.MapperPassenger));

            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
           
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PassengerMicroservice.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, PassengerContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/error-development");
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PassengerMicroservice.Api v1"));
            
            //Migrate
           // db.Database.Migrate();
            
            
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
