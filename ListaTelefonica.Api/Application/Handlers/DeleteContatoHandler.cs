using ListaTelefonica.Api.Application.Commands;
using ListaTelefonica.Api.Services;
using MediatR;

namespace ListaTelefonica.Api.Application.Handlers
{
    public class DeleteContatoHandler : IRequestHandler<DeleteContatoCommand, bool>
    {
        private readonly ContatoService _contatoService;

        public DeleteContatoHandler(ContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        public async Task<bool> Handle(DeleteContatoCommand request, CancellationToken cancellationToken)
        {
            await _contatoService.DeleteAsync(request.Id); // ✅ atualizado
            return true;
        }
    }
}
