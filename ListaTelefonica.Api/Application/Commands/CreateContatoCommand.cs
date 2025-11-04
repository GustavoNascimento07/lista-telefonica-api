using ListaTelefonica.Api.Domain;
using MediatR;

namespace ListaTelefonica.Api.Application.Commands
{
    public class CreateContatoCommand : IRequest<Contato>
    {
        public string Nome { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
    }
}
