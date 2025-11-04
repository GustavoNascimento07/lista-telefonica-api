using ListaTelefonica.Api.Application.Queries;
using ListaTelefonica.Api.Domain;
using ListaTelefonica.Api.Services;
using MediatR;

namespace ListaTelefonica.Api.Application.Handlers
{
    public class GetContatoByIdHandler : IRequestHandler<GetContatoByIdQuery, Contato?>
    {
        private readonly ContatoService _contatoService;

        public GetContatoByIdHandler(ContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        public async Task<Contato?> Handle(GetContatoByIdQuery request, CancellationToken cancellationToken)
        {
            return await _contatoService.GetByIdAsync(request.Id); // ✅ atualizado
        }
    }
}
