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
    public class JourneyController : ControllerBase
    {
        private readonly IJourneyAppServices _journeyAppService;

        public JourneyController(IJourneyAppServices jounerAppService)=> _journeyAppService= jounerAppService;
            // GET: api/<JourneyController>
        [HttpGet]
        public async Task<IEnumerable<Journey>> Get()
        {
            return await _journeyAppService.GetJourneyAllAsync();
        }

        // GET api/<JourneyController>/5
        [HttpGet("{id}")]
        public async Task<Journey> Get(int id)
        {
            return await _journeyAppService.GetJourneyAsync(id);
        }

        // POST api/<JourneyController>
        [HttpPost]
        public async Task Post([FromBody] Journey value)
        {
            await _journeyAppService.AddJourneyAsync(value);
        }

        // PUT api/<JourneyController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Journey value)
        {
            value.IdJourney = id;
            await _journeyAppService.EditJourneyAsync(value);
        }


        // DELETE api/<JourneyController>/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            await _journeyAppService.DeleteJourneyAsync(id);
        }
    }
}
