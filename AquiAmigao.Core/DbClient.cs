using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AquiAmigao.Core
{
    public class DbClient : IDbClient
    {
        private readonly IMongoCollection<Usuario> _usuarios;
        public DbClient(IOptions<AquiAmigaoDBConfig> options)
        {
            var client = new MongoClient(options.Value.Connection_String);
            var database = client.GetDatabase(options.Value.Database_Name);
            _usuarios = database.GetCollection<Usuario>(options.Value.Usuarios_Collection_Name);
        }

        public IMongoCollection<Usuario> GetUsuariosCollection() => _usuarios;
    }
}
