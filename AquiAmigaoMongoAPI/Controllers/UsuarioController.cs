using AquiAmigao.Core;
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
            return Ok(_usuarioService.GetUsuarios());
        }

        [HttpGet("{id}", Name ="GetUsuario")]
        public IActionResult GetUsuario(string id)
        {
            return Ok(_usuarioService.GetUsuario(id));
        }

        [HttpPost]
        public IActionResult AddUsuario(Usuario usuario)
        {
            _usuarioService.AddUsuario(usuario);
            return CreatedAtRoute("GetUsuario", new { id = usuario.Id }, usuario);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUsuario(string id)
        {
            _usuarioService.DeleteUsuario(id);
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateUsuario(Usuario usuario)
        {
            return Ok(_usuarioService.UpdateUsuario(usuario));
        }
    }
}
