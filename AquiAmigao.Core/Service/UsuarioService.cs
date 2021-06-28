using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace AquiAmigao.Core
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IMongoCollection<Usuario> _usuarios;
        public UsuarioService(IDbClient dbClient)
        {
            _usuarios = dbClient.GetUsuariosCollection();
        }


        public List<Usuario> GetUsuarios() => _usuarios.Find(usuario => true).ToList();


        public Usuario GetUsuario(string id) => _usuarios.Find(usuario => usuario.Id == id).First();


        public Usuario AddUsuario(Usuario usuario)
        {
            _usuarios.InsertOne(usuario);
            return usuario;
        }


        public void DeleteUsuario(string id)
        {
            _usuarios.DeleteOne(usuario => usuario.Id == id);
        }


        public Usuario UpdateUsuario(Usuario usuario)
        {
            GetUsuario(usuario.Id);
            _usuarios.ReplaceOne(u => u.Id == usuario.Id, usuario);
            return usuario;
        }
    }
}
