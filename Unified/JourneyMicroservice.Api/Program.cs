using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;


namespace JourneyMicroservice.Api
{
    public class Program
    {
        public static int Main(string[] args)
        {
  
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateBootstrapLogger();

            Log.Information("Starting up!");

            try
            {
                CreateHostBuilder(args).Build().Run();

                Log.Information("Stopped cleanly");
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "An unhandled exception occured during bootstrapping");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
               Host.CreateDefaultBuilder(args)
                   .UseSerilog((context, services, configuration) => configuration
                       .ReadFrom.Configuration(context.Configuration)
                       .ReadFrom.Services(services)
                       .Enrich.FromLogContext()
                       .WriteTo.Console()
                   )
                   .ConfigureWebHostDefaults(webBuilder => {
                       webBuilder.UseStartup<Startup>();
                       webBuilder.UseKestrel(opt =>
                       {
                           opt.AddServerHeader = false;
                           opt.Limits.MaxRequestLineSize = 16 * 1024;
                           IWebHostEnvironment service = (IWebHostEnvironment)opt.ApplicationServices.GetService(typeof(IWebHostEnvironment));
                           if (service.EnvironmentName == Environments.Production ||
                           service.EnvironmentName == Environments.Staging)
                           {
                               opt.ConfigureHttpsDefaults(

                                   listenOptions =>
                                   {
                                       listenOptions.ServerCertificate = new System.Security.Cryptography.X509Certificates.X509Certificate2("cert.pfx", "ftx131211");
                                   });
                           }
                       });
                   });
         
    }
}
