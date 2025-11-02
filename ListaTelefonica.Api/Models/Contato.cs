using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ListaTelefonica.Api.Models
{
    public class Contato
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("nome")]
        public string Nome { get; set; } = string.Empty;

        [BsonElement("telefone")]
        public string Telefone { get; set; } = string.Empty;

        [BsonElement("email")]
        public string Email { get; set; } = string.Empty;
    }
}
