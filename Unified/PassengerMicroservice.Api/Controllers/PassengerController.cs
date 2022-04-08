using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PassengerMicroservice.Api.Models;
using PassengerMicroservice.AppServices;
using PassengerMicroservice.Core.Entity;
using PassengerMicroservice.Passenger.Dto;
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
        public async Task<List<PassengerDto>> Get()
        {
            List<PassengerDto> passengers = await _passengerAppServices.GetPassengerAllAsync(); 
          
           _logger.LogInformation("Total passengers: " + passengers?.Count);
            return passengers;
        }

        // GET api/<PassengerController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PassengerDto>> Get(int id)
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
        public async  Task Post([FromBody] PassengerDto value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            else
            {

                await _passengerAppServices.AddPassengerAsync(value);
            }

            
        }

        // PUT api/<PassengerController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] PassengerDto value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            else
            {
                value.IdPassenger = id;
                await _passengerAppServices.EditPassengerAsync(value);

            }

            
        }

        // DELETE api/<PassengerController>/5
        [HttpDelete("{id}")]
        public async  Task Delete(int id)
        {

            await _passengerAppServices.DeletePassengerAsync(id);
            
        }
    }
}
