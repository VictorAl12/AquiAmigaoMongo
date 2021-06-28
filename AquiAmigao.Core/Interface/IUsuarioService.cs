using AquiAmigao.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquiAmigao.Core
{
    public interface IUsuarioService
    {
        List<UsuarioResponse> GetUsuarios();
        UsuarioResponse GetUsuario(string id);
        BaseResponse AddUsuario(UsuarioRequest request);
        BaseResponse UpdateUsuario(UsuarioRequest request);
        BaseResponse DeleteUsuario(string id);
    }
}
