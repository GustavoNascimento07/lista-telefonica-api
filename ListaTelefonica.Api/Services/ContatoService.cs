using ListaTelefonica.Api.Domain;
using MongoDB.Driver;

namespace ListaTelefonica.Api.Services
{
    public class ContatoService
    {
        private readonly IMongoCollection<Contato> _contatos;

        public ContatoService(IConfiguration config)
        {
            ////////////////////////////
            // Cria o cliente MongoDB //
            ////////////////////////////
            var client = new MongoClient(config["MongoDb:ConnectionString"]);

            //////////////////////////
            // Pega o banco de dados//
            //////////////////////////
            var database = client.GetDatabase(config["MongoDb:Database"]);

            ////////////////////////////////////////
            // Pega a coleção (tabela de contatos)//
            ////////////////////////////////////////
            _contatos = database.GetCollection<Contato>(config["MongoDb:Collection"]);
        }

        ///////////////////////////////////
        // 🔹 Retorna todos os contatos ///
        ///////////////////////////////////
        public async Task<List<Contato>> GetAsync() =>
            await _contatos.Find(c => true).ToListAsync();

        ///////////////////////////////////
        // 🔹 Retorna um contato pelo ID ///
        ///////////////////////////////////
        public async Task<Contato?> GetByIdAsync(string id) =>
            await _contatos.Find(c => c.Id == id).FirstOrDefaultAsync();

        /////////////////////////////
        // 🔹 Cria um novo contato //
        /////////////////////////////
        public async Task CreateAsync(Contato contato) =>
            await _contatos.InsertOneAsync(contato);

        ///////////////////////////////////////
        // 🔹 Atualiza um contato existente ///
        ///////////////////////////////////////
        public async Task UpdateAsync(string id, Contato contato) =>
            await _contatos.ReplaceOneAsync(c => c.Id == id, contato);

        ///////////////////////////////////////
        // 🔹 Deleta um contato pelo ID ///////
        ///////////////////////////////////////
        public async Task DeleteAsync(string id) =>
            await _contatos.DeleteOneAsync(c => c.Id == id);
    }
}
