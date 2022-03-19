using JourneyMicroservice.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace TicketMicroservice.AppServices
{
    public class PassengerAppServices
    {
        private readonly IHttpClientFactory _clientFactory;
        public PassengerAppServices(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<PassengerMicroservice.Core.Entity.Passenger> GetJourney(int id)
        {


            HttpClient client = _clientFactory.CreateClient();
            HttpResponseMessage response;
            String url = " https://localhost:733/api/Passenger/";

            response = await client.GetAsync($"{url}/{id}");
            PassengerMicroservice.Core.Entity.Passenger passenger;
            if (response.IsSuccessStatusCode)
            {
                passenger = Newtonsoft.Json.JsonConvert.DeserializeObject<PassengerMicroservice.Core.Entity.Passenger>(
                    await response.Content.ReadAsStringAsync());

                return passenger;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }

        }
    }
}
