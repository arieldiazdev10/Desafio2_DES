using Desafio2_DES.BL.Interfaces;
using Desafio2_DES.Common;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Desafio2_DES.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipanteController(IParticipanteService service) : ControllerBase
    {
        // GET: api/participante
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ParticipanteDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var result = await service.GetAllAsync();
            return Ok(result);
        }

        // GET api/participante/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ParticipanteDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await service.GetByIdAsync(id);
            return result != null ? Ok(result) : NotFound();
        }

        // POST api/participante
        [HttpPost]
        [ProducesResponseType(typeof(ParticipanteDto), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post([FromBody] CreateParticipanteDto model)
        {
            var result = await service.CreateAsync(model);
            return CreatedAtAction(nameof(Get), new { id = result.IdParticipante }, result);
        }

        // PUT api/participante/5
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put(int id, [FromBody] CreateParticipanteDto model)
        {
            var result = await service.UpdateAsync(id, model);
            return result ? NoContent() : NotFound();
        }

        // DELETE api/participante/5
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await service.DeleteAsync(id);
            return result ? NoContent() : NotFound();
        }
    }
}