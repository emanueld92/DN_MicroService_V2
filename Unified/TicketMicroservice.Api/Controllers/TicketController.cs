using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketMicroservice.AppServices;
using TicketMicroservice.Core.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TicketMicroservice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {

        private readonly ITicketAppServices _ticketAppServices;
        public TicketController(ITicketAppServices ticketAppServices) => _ticketAppServices = ticketAppServices;

        // GET: api/<TicketController>
        [HttpGet]
        public async Task<IEnumerable<Ticket>> GetAsync()
        {
            return await _ticketAppServices.GetTicketAllAsync();
        }

        // GET api/<TicketController>/5
        [HttpGet("{id}")]
        public async Task<Ticket> GetAsync(int id)
        {
            return await _ticketAppServices.GetTicketAsync(id);
        }

        // POST api/<TicketController>
        [HttpPost]
        public async void Post([FromBody] Ticket value)
        {
            await _ticketAppServices.AddTicketAsync(value);
        }

        // PUT api/<TicketController>/5
        [HttpPut("{id}")]
        public async void Put(int id, [FromBody] Ticket value)
        {

            value.IdTicket = id;
            await _ticketAppServices.EditTicketAsync(value);
        }

        // DELETE api/<TicketController>/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
           await _ticketAppServices.DeleteTicketAsync(id);
        }
    }
}
