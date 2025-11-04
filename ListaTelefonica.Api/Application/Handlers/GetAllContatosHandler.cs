using ListaTelefonica.Api.Application.Queries;
using ListaTelefonica.Api.Domain;
using ListaTelefonica.Api.Services;
using MediatR;

namespace ListaTelefonica.Api.Application.Handlers
{
    public class GetAllContatosHandler : IRequestHandler<GetAllContatosQuery, List<Contato>>
    {
        private readonly ContatoService _contatoService;

        public GetAllContatosHandler(ContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        public async Task<List<Contato>> Handle(GetAllContatosQuery request, CancellationToken cancellationToken)
        {
            return await _contatoService.GetAsync(); // ✅ atualizado
        }
    }
}
