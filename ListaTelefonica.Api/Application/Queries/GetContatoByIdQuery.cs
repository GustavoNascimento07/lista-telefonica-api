using ListaTelefonica.Api.Domain;
using MediatR;

namespace ListaTelefonica.Api.Application.Queries
{
    public class GetContatoByIdQuery : IRequest<Contato?>
    {
        public string Id { get; set; }

        public GetContatoByIdQuery(string id)
        {
            Id = id;
        }
    }
}
