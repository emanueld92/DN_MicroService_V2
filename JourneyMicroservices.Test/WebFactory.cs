using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMicroservices.Test
{
    public class WebFactory:WebApplicationFactory<JourneyMicroservice.Api.Program>
    {

        protected override IHost CreateHost(IHostBuilder builder)
        {

            builder.ConfigureServices(services =>
            {

            });
            return base.CreateHost(builder);
        }
    }
}
