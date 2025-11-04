using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ListaTelefonica.Api.Domain
{
    public class Contato
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        public string Nome { get; set; } = string.Empty;

        public string Telefone { get; set; } = string.Empty;
    }
}
