using AquiAmigao.Core.Interface;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquiAmigao.Core.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IMongoCollection<Usuario> _usuarios;
        public UsuarioRepository(IDbClient dbClient)
        {
            _usuarios = dbClient.GetUsuariosCollection();
        }


        public List<Usuario> GetUsuarios() => _usuarios.Find(usuario => true).ToList();

        public Usuario GetUsuario(string id) => _usuarios.Find(usuario => usuario.Id == id).First();

        public Usuario GetByEmail(string email) => _usuarios.Find(usuario => usuario.Email == email).First();

        public Usuario AddUsuario(Usuario usuario)
        {
            _usuarios.InsertOne(usuario);
            return usuario;
        }

        public Usuario UpdateUsuario(Usuario usuario)
        {
            GetUsuario(usuario.Id);
            _usuarios.ReplaceOne(u => u.Id == usuario.Id, usuario);
            return usuario;
        }

        public void DeleteUsuario(string id)
        {
            _usuarios.DeleteOne(usuario => usuario.Id == id);
        }
    }
}
