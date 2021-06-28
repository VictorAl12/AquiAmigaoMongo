using AquiAmigao.Core.Interface;
using AquiAmigao.Core.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace AquiAmigao.Core
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public List<UsuarioResponse> GetUsuarios()
        {
            var entity = _usuarioRepository.GetUsuarios();

            List<UsuarioResponse> response = new List<UsuarioResponse>();

            entity.ForEach(u => {
                response.Add(new UsuarioResponse()
                {
                    Id = u.Id,
                    Nome = u.Nome,
                    Email = u.Email,
                    Telefone = u.Telefone
                });
            });

            return response;
        }

        public UsuarioResponse GetUsuario(string id)
        {
            var entity = _usuarioRepository.GetUsuario(id);

            return new UsuarioResponse()
            {
                Id = entity.Id,
                Nome = entity.Nome,
                Email = entity.Email,
                Telefone = entity.Telefone
            };
        }

        public BaseResponse AddUsuario(UsuarioRequest request)
        {
            if (request.Nome == "")
                return new BaseResponse() { StatusCode = 400, Mensagem = "Nome precisa ser preenchido" };
            if (request.Email == "")
                return new BaseResponse() { StatusCode = 400, Mensagem = "Email precisa ser preenchido" };

            var entity = _usuarioRepository.GetByEmail(request.Email);
            if (entity != null)
                return new BaseResponse() { StatusCode = 400, Mensagem = "Email ja foi cadastrado" };

            Usuario usuario = new Usuario();
            usuario.Id = request.Id;
            usuario.Nome = request.Nome;
            usuario.Email = request.Email;
            usuario.Telefone = request.Telefone;

            _usuarioRepository.AddUsuario(usuario);

            return new BaseResponse() { StatusCode = 201 };
        }

        public BaseResponse UpdateUsuario(UsuarioRequest request)
        {
            if (request.Nome == "")
                return new BaseResponse() { StatusCode = 400, Mensagem = "Nome precisa ser preenchido" };
            if (request.Email == "")
                return new BaseResponse() { StatusCode = 400, Mensagem = "Email precisa ser preenchido" };

            var entity = _usuarioRepository.GetByEmail(request.Email);
            if (entity != null)
                return new BaseResponse() { StatusCode = 400, Mensagem = "Email ja foi cadastrado" };

            Usuario usuario = new Usuario();
            usuario.Id = request.Id;
            usuario.Nome = request.Nome;
            usuario.Email = request.Email;
            usuario.Telefone = request.Telefone;

            _usuarioRepository.UpdateUsuario(usuario);

            return new BaseResponse() { StatusCode = 200 };
        }

        public BaseResponse DeleteUsuario(string id)
        {
            if (id == "")
                return new BaseResponse() { StatusCode = 400, Mensagem = "ID precisa ser preenchida" };

            _usuarioRepository.DeleteUsuario(id);
            return new BaseResponse() { StatusCode = 200 };
        }
    }
}
