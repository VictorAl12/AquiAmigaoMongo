using AquiAmigao.Core.Entity;
using AquiAmigao.Core.Interface;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace AquiAmigao.Core.Service
{
    public class PostService : IPostService
    {
        private readonly IMongoCollection<Post> _posts;
        //private readonly IMongoCollection<Usuario> _usuarios;
        public PostService(IDbClient dbClient)
        {
            _posts = dbClient.GetPostsCollection();
            //_usuarios = dbClient.GetUsuariosCollection();
        }

        public List<Post> GetPosts() => _posts.Find(post => true).ToList();

        public Post GetPost(string id) => _posts.Find(post => post.Id == id).First();
        //public Usuario GetUsuarioId(string id) => _usuarios.Find(usuario => usuario.Id == id).First();

        public Post AddPost(Post post)
        {
            //if(GetUsuarioId(post.UsuarioId) == null) { }

            _posts.InsertOne(post);
            return post;
        }
    }
}
