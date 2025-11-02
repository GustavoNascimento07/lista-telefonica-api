using ListaTelefonica.Api.Models;
using MongoDB.Driver;

namespace ListaTelefonica.Api.Services
{
    public class ContatoService
    {
        private readonly IMongoCollection<Contato> _contatos;

        public ContatoService(IConfiguration config)
        {
            var client = new MongoClient(config["MongoDb:ConnectionString"]);
            var database = client.GetDatabase(config["MongoDb:Database"]);
            _contatos = database.GetCollection<Contato>(config["MongoDb:Collection"]);
        }

        public List<Contato> Get() => _contatos.Find(c => true).ToList();

        public Contato Get(string id) => _contatos.Find(c => c.Id == id).FirstOrDefault();

        public void Create(Contato contato) => _contatos.InsertOne(contato);

        public void Update(string id, Contato contato) => _contatos.ReplaceOne(c => c.Id == id, contato);

        public void Delete(string id) => _contatos.DeleteOne(c => c.Id == id);
    }
}
