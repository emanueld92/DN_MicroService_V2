using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PassengerMicroservice.Api.Models;
using PassengerMicroservice.AppServices;
using PassengerMicroservice.Core.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PassengerMicroservice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {

        private readonly IPassengerAppServices _passengerAppServices;
        private readonly ILogger _logger;
        public PassengerController(IPassengerAppServices passengerAppServices, ILogger<PassengerController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _passengerAppServices = passengerAppServices ;
        } 

        // GET: api/<PassengerController>
        [HttpGet]
        public async Task<IEnumerable<Passenger>> Get()
        {
            var passengers = await _passengerAppServices.GetPassengerAllAsync();
           _logger.LogInformation("Total passengers: " + passengers?.Count);
            return passengers;
        }

        // GET api/<PassengerController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Passenger>> Get(int id)
        {

            var passenger = await _passengerAppServices.GetPassengerAsync(id);

            if (passenger == null)
            {
                return NotFound("Passenger no found");


            }

            return Ok(passenger);
            
        }

        // POST api/<PassengerController>
        [HttpPost]
        public async  Task Post([FromBody] PassengerViewModel value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            Passenger passenger = new Passenger
            {
                FirstName=value.FirstName,
                LastName=value.LastName,
                Age=value.Age
            };
            await _passengerAppServices.AddPassengerAsync(passenger);
            
        }

        // PUT api/<PassengerController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] PassengerViewModel value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            Passenger passenger = new Passenger
            {
                IdPassenger = id,
                FirstName = value.FirstName,
                LastName = value.LastName,
                Age = value.Age
            };

            await _passengerAppServices.EditPassengerAsync(passenger);
            
        }

        // DELETE api/<PassengerController>/5
        [HttpDelete("{id}")]
        public async  Task Delete(int id)
        {

            await _passengerAppServices.DeletePassengerAsync(id);
            
        }
    }
}
