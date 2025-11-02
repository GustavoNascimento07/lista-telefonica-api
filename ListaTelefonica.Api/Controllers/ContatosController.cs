using ListaTelefonica.Api.Models;
using ListaTelefonica.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace ListaTelefonica.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContatosController : ControllerBase
    {
        private readonly ContatoService _service;

        public ContatosController(ContatoService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Contato>> Get() => _service.Get();

        [HttpGet("{id:length(24)}", Name = "GetContato")]
        public ActionResult<Contato> Get(string id)
        {
            var contato = _service.Get(id);

            if (contato == null)
                return NotFound(new { message = "Contato não encontrado." });

            return contato;
        }

        [HttpPost]
        public ActionResult<Contato> Create(Contato contato)
        {
            _service.Create(contato);
            return CreatedAtRoute("GetContato", new { id = contato.Id }, contato);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Contato contato)
        {
            var existing = _service.Get(id);

            if (existing == null)
                return NotFound(new { message = "Contato não encontrado." });

            _service.Update(id, contato);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var contato = _service.Get(id);

            if (contato == null)
                return NotFound(new { message = "Contato não encontrado." });

            _service.Delete(id);
            return Ok(new { message = "Contato removido com sucesso." });
        }
    }
}
