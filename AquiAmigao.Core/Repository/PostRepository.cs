using AquiAmigao.Core.Entity;
using AquiAmigao.Core.Interface;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquiAmigao.Core.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly IMongoCollection<Post> _posts;
        private readonly IMongoCollection<Usuario> _usuarios;
        public PostRepository(IDbClient dbClient)
        {
            _posts = dbClient.GetPostsCollection();
            _usuarios = dbClient.GetUsuariosCollection();
        }

        public List<Post> GetPosts() => _posts.Find(post => true).ToList();

        public Post GetPost(string id) => _posts.Find(post => post.Id == id).First();

        public Usuario GetByUsuarioId(string id) => _usuarios.Find(usuario => usuario.Id == id).First();

        public Post AddPost(Post post)
        {
            _posts.InsertOne(post);
            return post;
        }

        public void DeletePost(string id)
        {
            _usuarios.DeleteOne(post => post.Id == id);
        }
    }
}
