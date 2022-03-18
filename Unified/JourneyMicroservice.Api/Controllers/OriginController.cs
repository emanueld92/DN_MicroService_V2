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
    public class OriginController : ControllerBase
    {
        private readonly IOriginAppServices _originAppServices;

        public OriginController(IOriginAppServices originAppServices)
        {
            _originAppServices = originAppServices;
        }



        // GET: api/<OriginController>
        [HttpGet]
        public async Task<IEnumerable<Origin>> Get()
        {
            return await _originAppServices.GetOriginAllAsync();
        }

        // GET api/<OriginController>/5
        [HttpGet("{id}")]
        public async Task <Origin> Get(int id)
        {
            return await _originAppServices.GetOriginAsync(id);
        }

        // POST api/<OriginController>
        [HttpPost]
        public async Task Post([FromBody] Origin value)
        {
             await _originAppServices.AddOriginAsync(value);
        }

        // PUT api/<OriginController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Origin value)
        {
            value.OriginId = id;
            await _originAppServices.EditOriginAsync(value);
        }

        // DELETE api/<OriginController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _originAppServices.DeleteOriginAsync(id);
        }
    }
}
