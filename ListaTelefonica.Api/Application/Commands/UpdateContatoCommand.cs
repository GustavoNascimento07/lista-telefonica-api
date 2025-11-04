using ListaTelefonica.Api.Domain;
using MediatR;

namespace ListaTelefonica.Api.Application.Commands
{
    public class UpdateContatoCommand : IRequest<Contato?>
    {
        public string Id { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
    }
}
