using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Services;
using System;
using System.Collections.Generic;

namespace Aplication.Controllers {

    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UsuarioController : ControllerBase {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService) {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public ActionResult<List<Usuario>> Get() {
            try {
                return Ok(_usuarioService.Get());
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return BadRequest("Erro ao buscar usuarios.");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Usuario> Get(string id) {
            try {
                var usuario = _usuarioService.Get(id);

                if (usuario != null) {
                    return Ok(usuario);
                }

                return NoContent();
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return BadRequest("Erro ao buscar usuario por id.");
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Usuario usuario) {
            try {
                _usuarioService.Create(usuario);

                return Ok(usuario);
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return BadRequest("Erro ao salvar usuario.");
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Usuario> Put(string id, [FromBody] Usuario novaUsuario) {
            try {
                var usuarioVelho = _usuarioService.Get(id);

                if (usuarioVelho != null) {
                    _usuarioService.Update(id, novaUsuario);
                    return Ok(novaUsuario);
                }

                return NoContent();
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return BadRequest("Erro ao fazer update da usuario.");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id) {
            try {
                var usuario = _usuarioService.Get(id);

                if (usuario != null) {
                    _usuarioService.Remove(id);
                    return Ok(usuario);
                }

                return NoContent();
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return BadRequest("Erro ao deletar usuario.");
            }
        }
    }
}