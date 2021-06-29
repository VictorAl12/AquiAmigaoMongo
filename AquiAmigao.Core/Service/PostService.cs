using AquiAmigao.Core.Entity;
using AquiAmigao.Core.Interface;
using AquiAmigao.Core.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace AquiAmigao.Core.Service
{
    public class PostService : IPostService
    {
        private IPostRepository _postRepository;
        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public List<PostResponse> GetPosts()
        {
            var entity = _postRepository.GetPosts();

            List<PostResponse> response = new List<PostResponse>();

            entity.ForEach(p => {
                response.Add(new PostResponse()
                {
                    Id = p.Id,
                    Conteudo = p.Conteudo,
                    UsuarioId = p.UsuarioId
                });
            });

            return response;
        }

        public PostResponse GetPost(string id)
        {
            var entity = _postRepository.GetPost(id);

            return new PostResponse()
            {
                Id = entity.Id,
                Conteudo = entity.Conteudo,
                UsuarioId = entity.UsuarioId
            };
        }

        public BaseResponse AddPost(PostRequest request)
        {
            if (request.Conteudo == "")
                return new BaseResponse() { StatusCode = 400, Mensagem = "Post precisa ter conteudo" };
            if (request.UsuarioId == "")
                return new BaseResponse() { StatusCode = 400, Mensagem = "Usuario ID precisa ser preenchido" };

            var entity = _postRepository.GetByUsuarioId(request.UsuarioId);
            if (entity == null)
                return new BaseResponse() { StatusCode = 400, Mensagem = "Usuario precisa estar cadastrado" };

            Post post = new Post();
            post.Id = request.Id;
            post.Conteudo = request.Conteudo;
            post.UsuarioId = request.UsuarioId;

            _postRepository.AddPost(post);

            return new BaseResponse() { StatusCode = 201 };
        }

        public BaseResponse UpdatePost(PostRequest request)
        {
            if (request.Conteudo == "")
                return new BaseResponse() { StatusCode = 400, Mensagem = "Post precisa ter conteudo" };
            if (request.UsuarioId == "")
                return new BaseResponse() { StatusCode = 400, Mensagem = "Usuario ID precisa ser preenchido" };

            var entity = _postRepository.GetByUsuarioId(request.UsuarioId);
            if (entity == null)
                return new BaseResponse() { StatusCode = 400, Mensagem = "Usuario precisa estar cadastrado" };

            Post post = new Post();
            post.Id = request.Id;
            post.Conteudo = request.Conteudo;
            post.UsuarioId = request.UsuarioId;

            _postRepository.AddPost(post);

            return new BaseResponse() { StatusCode = 200 };
        }

        public BaseResponse DeleteUsuario(string id)
        {
            if (id == "")
                return new BaseResponse() { StatusCode = 400, Mensagem = "ID precisa ser preenchida" };

            _postRepository.DeletePost(id);
            return new BaseResponse() { StatusCode = 200 };
        }
    }
}
