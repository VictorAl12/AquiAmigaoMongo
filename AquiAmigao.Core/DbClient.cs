using AquiAmigao.Core.Entity;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AquiAmigao.Core
{
    public class DbClient : IDbClient
    {
        private readonly IMongoCollection<Usuario> _usuarios;
        private readonly IMongoCollection<Post> _posts;
        public DbClient(IOptions<AquiAmigaoDBConfig> options)
        {
            var client = new MongoClient(options.Value.Connection_String);
            var database = client.GetDatabase(options.Value.Database_Name);
            _usuarios = database.GetCollection<Usuario>(options.Value.Usuarios_Collection_Name);
            _posts = database.GetCollection<Post>(options.Value.Posts_Collection_Name);
        }

        public IMongoCollection<Usuario> GetUsuariosCollection() => _usuarios;
        public IMongoCollection<Post> GetPostsCollection() => _posts;
    }
}
