using JourneyMicroservice.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TicketMicroservice.AppServices
{
    public class JourneyAppServices
    {
        private readonly IHttpClientFactory _clientFactory;
        public JourneyAppServices(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<JourneyMicroservice.Core.Entity.Journey> GetJourney(int id)
        {


            HttpClient client = _clientFactory.CreateClient();
            HttpResponseMessage response;
            String url = "https://localhost:733/api/Journey/";

            response = await client.GetAsync($"{url}/{id}");
            JourneyMicroservice.Core.Entity.Journey journey;
            if (response.IsSuccessStatusCode)
            {
                journey = Newtonsoft.Json.JsonConvert.DeserializeObject<JourneyMicroservice.Core.Entity.Journey>(
                    await response.Content.ReadAsStringAsync());

                return journey;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }

            //var journeyId = ticket.JourneyId;

            //var ticket = await _repository.GetAsync(ticketId);
            //HttpClient passenger = new HttpClient();
            //HttpClient journey = new HttpClient();
            //var passengerId = ticket.PassengerId;

            //HttpResponseMessage responsePassenger;
            //HttpResponseMessage responseJourney;



            //String urlPassenger = $" https://localhost:733/api/Passenger/{passengerId}";
            //responsePassenger = await passenger.GetAsync(urlPassenger);
            //responseJourney = await Journey.GetAsync(urljourney);

            //var source = ticket;
            //source.JourneyId = responseJourney;
            //    soruce.Passenger = responseJourney;


            
        }
    }
}
