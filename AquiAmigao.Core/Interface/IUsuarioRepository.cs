using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquiAmigao.Core.Interface
{
    public interface IUsuarioRepository
    {
        List<Usuario> GetUsuarios();
        Usuario GetUsuario(string id);
        Usuario GetByEmail(string email);
        Usuario AddUsuario(Usuario usuario);
        Usuario UpdateUsuario(Usuario usuario);
        void DeleteUsuario(string id);
    }
}
