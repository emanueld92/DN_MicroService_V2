using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketMicroservice.Api.Models;
using TicketMicroservice.AppServices;
using TicketMicroservice.Core.Entity;
using TicketMicroservice.Ticket.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TicketMicroservice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {

        private readonly ITicketAppServices _ticketAppServices;
        private readonly IPassengerAppServices _passengerAppServices;
        private readonly IJourneyAppServices _journeyAppServices;
        private readonly ILogger _logger;
        public TicketController(ILogger<TicketController> logger, ITicketAppServices ticketAppServices, IPassengerAppServices passengerAppServices,IJourneyAppServices journeyAppServices)
        {
            _ticketAppServices = ticketAppServices;
            _passengerAppServices = passengerAppServices;
            _journeyAppServices = journeyAppServices;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/<TicketController>
        [HttpGet]
        public async Task<List<TicketDto>> GetAsync()
        {

            List<TicketDto> tickets= await _ticketAppServices.GetTicketAllAsync();
           
            _logger.LogInformation("Total tickets: " + tickets?.Count);
            return tickets;
        }

        // GET api/<TicketController>/5
        [HttpGet("{id}")]
        public async Task<TicketDto> GetAsync(int id)
        {
            return await _ticketAppServices.GetTicketAsync(id);
        }

        // POST api/<TicketController>
        [HttpPost]
        public async void Post([FromBody] TicketDto value)
        {
            

            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            var passenger = await _passengerAppServices.GetPassenger(value.PassengerId);
            if (passenger == null)
            {
                throw new Exception("This passenger is not exist");
            }

            var journey = await _journeyAppServices.GetJourney(value.JourneyId);

            if (journey == null)
            {
                throw new Exception("This passenger is not exist");
            }

            TicketDto ticket = new TicketDto
            {
                JourneyId = value.JourneyId,
                PassengerId = value.PassengerId,
                Seat = value.Seat
                
            };
            await _ticketAppServices.AddTicketAsync(ticket);
        }

        // PUT api/<TicketController>/5
        [HttpPut("{id}")]
        public async void Put(int id, [FromBody] TicketViewModel value)
        {

            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            var passenger = await _passengerAppServices.GetPassenger(value.PassengerId);
            if (passenger == null)
            {
                throw new Exception("unrecorded passenger error");
            }
            var journey = await _journeyAppServices.GetJourney(value.JourneyId);

            if (journey == null)
            {
                throw new Exception("unregistered destination");
            }
            TicketDto ticket = new TicketDto
            {

                IdTicket = id,
                PassengerId=value.PassengerId,
                JourneyId=value.JourneyId,
                Seat=value.Seat
            };
            await _ticketAppServices.EditTicketAsync(ticket);
        }

        // DELETE api/<TicketController>/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
           await _ticketAppServices.DeleteTicketAsync(id);
        }
    }
}
