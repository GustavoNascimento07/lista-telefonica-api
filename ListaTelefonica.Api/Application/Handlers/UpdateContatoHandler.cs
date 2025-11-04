using ListaTelefonica.Api.Application.Commands;
using ListaTelefonica.Api.Domain;
using ListaTelefonica.Api.Services;
using MediatR;

namespace ListaTelefonica.Api.Application.Handlers
{
    public class UpdateContatoHandler : IRequestHandler<UpdateContatoCommand, Contato?>
    {
        private readonly ContatoService _contatoService;

        public UpdateContatoHandler(ContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        public async Task<Contato?> Handle(UpdateContatoCommand request, CancellationToken cancellationToken)
        {
            var contato = new Contato
            {
                Id = request.Id,
                Nome = request.Nome,
                Telefone = request.Telefone
            };

            await _contatoService.UpdateAsync(request.Id, contato); // ✅ atualizado
            return contato;
        }
    }
}
