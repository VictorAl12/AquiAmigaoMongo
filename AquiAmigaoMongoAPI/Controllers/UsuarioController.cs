using AquiAmigao.Core;
using AquiAmigao.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquiAmigaoMongoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult GetUsuarios()
        {
            var response = _usuarioService.GetUsuarios();
            return new ObjectResult(response) { StatusCode = 200 };
        }

        [HttpGet("{id}", Name = "GetUsuario")]
        public IActionResult GetUsuario(string id)
        {
            var response = _usuarioService.GetUsuario(id);
            return new ObjectResult(response) { StatusCode = 200 };
        }

        [HttpPost]
        public IActionResult AddUsuario(UsuarioRequest request)
        {
            var response = _usuarioService.AddUsuario(request);
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        [HttpPut]
        public IActionResult UpdateUsuario(UsuarioRequest request)
        {
            var response = _usuarioService.UpdateUsuario(request);
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUsuario(string id)
        {
            var response = _usuarioService.DeleteUsuario(id);
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}
