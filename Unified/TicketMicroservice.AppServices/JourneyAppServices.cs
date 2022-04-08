using JourneyMicroservice.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TicketMicroservice.AppServices
{
    public class JourneyAppServices: IJourneyAppServices
    {
        private readonly IHttpClientFactory _clientFactory;
        public JourneyAppServices(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<JourneyMicroservice.Core.Entity.Journey> GetJourney(int id)
        {


            HttpClient client = _clientFactory.CreateClient("journey");
            HttpResponseMessage response;
            String url = "Journey";

            response = await client.GetAsync($"{url}/{id}");
            JourneyMicroservice.Core.Entity.Journey journey;
            if (response.IsSuccessStatusCode)
            {
                journey = Newtonsoft.Json.JsonConvert.DeserializeObject<Journey>(
                await response.Content.ReadAsStringAsync());

                return journey;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }




            
        }
    }
}
