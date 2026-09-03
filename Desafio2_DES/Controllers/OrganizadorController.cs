using Desafio2_DES.BL.Interfaces;
using Desafio2_DES.Common;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Desafio2_DES.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizadorController(IOrganizadorService service) : ControllerBase
    {
        // GET: api/organizador
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<OrganizadorDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var result = await service.GetAllAsync();
            return Ok(result);
        }

        // GET api/organizador/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(OrganizadorDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await service.GetByIdAsync(id);
            return result != null ? Ok(result) : NotFound();
        }

        // POST api/organizador
        [HttpPost]
        [ProducesResponseType(typeof(OrganizadorDto), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post([FromBody] CreateOrganizadorDto model)
        {
            var result = await service.CreateAsync(model);
            return CreatedAtAction(nameof(Get), new { id = result.IdOrganizador }, result);
        }

        // PUT api/organizador/5
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put(int id, [FromBody] CreateOrganizadorDto model)
        {
            var result = await service.UpdateAsync(id, model);
            return result ? NoContent() : NotFound();
        }

        // DELETE api/organizador/5
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