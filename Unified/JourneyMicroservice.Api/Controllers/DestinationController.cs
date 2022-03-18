using JourneyMicroservice.AppServices;
using JourneyMicroservice.Core.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JourneyMicroservice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationController : ControllerBase
    {

        private readonly IDestinationAppServices _destinationAppServices;


        //
        public DestinationController(IDestinationAppServices destinationAppServices) => _destinationAppServices = destinationAppServices;
     
        
        
        // GET: api/<DestinationController>
        [HttpGet]
        public async Task<IEnumerable<Destination>> Get()
        {
            return await _destinationAppServices.GetDestinationAllAsync();
        }

        // GET api/<DestinationController>/5
        [HttpGet("{id}")]
        public async Task<Destination> GetAsync(int id)
        {
            return await _destinationAppServices.GetDestinationAsync(id);
        }

        // POST api/<DestinationController>
        [HttpPost]
        public async Task Post([FromBody] Destination value)
        {
            await _destinationAppServices.AddDestinationAsync(value);        }

        // PUT api/<DestinationController>/5
        [HttpPut("{id}")]
        public async Task PutAsync(int id, [FromBody] Destination value)
        {
            value.DestinationId = id;
            await _destinationAppServices.EditDestinationAsync(value);
        }

        // DELETE api/<DestinationController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _destinationAppServices.DeleteDestinationAsync(id);
        }
    }
}
