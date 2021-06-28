using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquiAmigao.Core
{
    public interface IUsuarioService
    {
        List<Usuario> GetUsuarios();
        Usuario GetUsuario(string id);
        Usuario AddUsuario(Usuario usuario);
        void DeleteUsuario(string id);
        Usuario UpdateUsuario(Usuario usuario);
    }
}
