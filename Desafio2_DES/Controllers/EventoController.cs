using Desafio2_DES.BL.Interfaces;
using Desafio2_DES.Entities.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Net;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Desafio2_DES.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController (IEventoService service): ControllerBase
    {
        // GET: api/evento
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EventoDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var result = await service.GetEventosAsync();
            return Ok(result);
        }

        // GET api/evento/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EventoDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        { 
            var result = await service.GetEventoByIdAsync(id);
            return result != null ? Ok(result) : NotFound();
        }

       
        // POST api/evento
        [HttpPost]
        [ProducesResponseType(typeof(EventoDto), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post([FromBody] EventoDto model)
        {
            var result = await service.InsertEventoAsync(model);
            return CreatedAtAction(nameof(Get), new { id = result.CodigoEvento }, result);
        }
        
        // PUT api/evento/5
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put(int id, [FromBody] EventoDto model)
        {
            var result = await service.UpdateEventoAsync(id, model);
            return result != null ? NoContent() : NotFound();
        }

        // DELETE api/evento/5
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete(int id) 
        { 
            var result = await service.DeleteEventoAsync(id);
            return result ? NoContent() : NotFound();
        }
        
    }
}
