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
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TicketMicroservice.AppServices;
using TicketMicroservice.Core.Entity;
using TicketMicroservice.EntityFramework;
using TicketMicroservice.EntityFramework.Repository;
using AutoMapper;
namespace TicketMicroservice.Api
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
            services.AddDbContext<TicketContext>(
                options => options.UseMySql(connectionStrig, ServerVersion.AutoDetect(connectionStrig)));
                //options.UseInMemoryDatabase(databaseName: "ticketMemory"));


            //Services Transient

            services.AddTransient<ITicketAppServices, TicketAppServices>();
            services.AddTransient<IJourneyAppServices, JourneyAppServices>();
            services.AddTransient<IPassengerAppServices, PassengerAppServices>();

            //repository
            services.AddTransient<IRepository<int,TicketMicroservice.Core.Entity.Ticket>, TicketRepository>();

            //SSl
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            //AppService to other Microservices
            services.AddHttpClient("passenger", client =>
            {

                client.BaseAddress = new Uri((Configuration["AppSettings:PassengerUrlBase"]));
            }).ConfigurePrimaryHttpMessageHandler(() => (clientHandler));

            services.AddHttpClient("journey", client =>
            {

                client.BaseAddress = new Uri((Configuration["AppSettings:JourneyUrlBase"]));
            }).ConfigurePrimaryHttpMessageHandler(() => (clientHandler));

            //AutoMapper
            services.AddAutoMapper(typeof(TicketMicroservice.AppServices.TicketMapper));

            //Newtonsoft add Controller
            services.AddControllers().AddNewtonsoftJson(x =>
                x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            //Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TicketMicroservice.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, TicketContext db)
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
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TicketMicroservice.Api v1"));
            //Migrate
            db.Database.Migrate();
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
