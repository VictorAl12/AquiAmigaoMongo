using MongoDB.Bson.Serialization.Attributes;

namespace AquiAmigao.Core.Entity
{
    public class Post
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string UsuarioId { get; set; }
        public string Conteudo { get; set; }
    }
}
