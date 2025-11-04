using ListaTelefonica.Api.Application.Commands;
using ListaTelefonica.Api.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ListaTelefonica.Api.Controllers
{
    [ApiController]
    [Route("contatos")]
    public class ContatosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContatosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateContatoCommand command)
        {
            var contato = await _mediator.Send(command);
            return Ok(contato);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contatos = await _mediator.Send(new GetAllContatosQuery());
            return Ok(contatos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var contato = await _mediator.Send(new GetContatoByIdQuery(id));
            if (contato == null) return NotFound();
            return Ok(contato);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, UpdateContatoCommand command)
        {
            command.Id = id;
            var contato = await _mediator.Send(command);
            return Ok(contato);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _mediator.Send(new DeleteContatoCommand(id));
            return result ? NoContent() : NotFound();
        }
    }
}
