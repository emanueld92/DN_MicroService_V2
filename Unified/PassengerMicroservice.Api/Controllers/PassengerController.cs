using Microsoft.AspNetCore.Mvc;
using PassengerMicroservice.AppServices;
using PassengerMicroservice.Core.Entity;
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

        public PassengerController(IPassengerAppServices passengerAppServices)=> _passengerAppServices = passengerAppServices;

        // GET: api/<PassengerController>
        [HttpGet]
        public async Task<IEnumerable<Passenger>> Get()
        {
            return await _passengerAppServices.GetPassengerAllAsync();
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
        public async  Task Post([FromBody] Passenger value)
        {
            
            await _passengerAppServices.AddPassengerAsync(value);
            
        }

        // PUT api/<PassengerController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Passenger value)
        {
            value.IdPassenger = id;
            await _passengerAppServices.EditPassengerAsync(value);
            
        }

        // DELETE api/<PassengerController>/5
        [HttpDelete("{id}")]
        public async  Task Delete(int id)
        {

            await _passengerAppServices.DeletePassengerAsync(id);
            
        }
    }
}
