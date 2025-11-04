using MediatR;

namespace ListaTelefonica.Api.Application.Commands
{
    public class DeleteContatoCommand : IRequest<bool>
    {
        public string Id { get; set; }

        public DeleteContatoCommand(string id)
        {
            Id = id;
        }
    }
}
