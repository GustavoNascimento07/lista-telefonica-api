using ListaTelefonica.Api.Domain;
using MediatR;
using System.Collections.Generic;

namespace ListaTelefonica.Api.Application.Queries
{
    public class GetAllContatosQuery : IRequest<List<Contato>>
    {
    }
}
