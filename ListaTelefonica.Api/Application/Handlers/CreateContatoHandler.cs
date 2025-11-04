using ListaTelefonica.Api.Application.Commands;
using ListaTelefonica.Api.Domain;
using ListaTelefonica.Api.Services;
using MediatR;

namespace ListaTelefonica.Api.Application.Handlers
{
    public class CreateContatoHandler : IRequestHandler<CreateContatoCommand, Contato>
    {
        private readonly ContatoService _contatoService;

        public CreateContatoHandler(ContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        public async Task<Contato> Handle(CreateContatoCommand request, CancellationToken cancellationToken)
        {
            var contato = new Contato
            {
                Nome = request.Nome,
                Telefone = request.Telefone
            };

            await _contatoService.CreateAsync(contato); // ✅ Usando método assíncrono
            return contato;
        }
    }
}
