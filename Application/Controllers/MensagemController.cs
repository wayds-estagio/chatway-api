using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Services;
using System;

namespace Aplication.Controllers {

    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class MensagemController : ControllerBase {
        private readonly MensagemService _mensagemService;
        //private readonly ChatWayHub _chatWayHub;

        public MensagemController(MensagemService usuarioService) {
            _mensagemService = usuarioService;
            //_chatWayHub = chatWayHub;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string chat, [FromQuery] string id) {
            return id == null ? GetByChat(chat) : GetByChatAndId(chat, id);
        }

        public IActionResult GetByChat(string chat) {
            try {
                return Ok(_mensagemService.Get(chat));
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return BadRequest("Erro ao buscar mensagens.");
            }
        }

        public IActionResult GetByChatAndId(string chat, string id) {
            try {
                return Ok(_mensagemService.Get(id, chat));
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return BadRequest("Erro ao buscar mensagens.");
            }
        }

        [HttpPost]
        //[Route("NomeDaRota")]
        public ActionResult Post([FromBody] Mensagem mensagem) {
            try {
                _mensagemService.Create(mensagem);

                return Ok(mensagem);
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return BadRequest("Erro ao salvar mensagem.");
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Mensagem> Put(string id, [FromBody] Mensagem mensagemNova) {
            try {
                var mensagemVelha = _mensagemService.Get(id);

                if (mensagemVelha != null) {
                    _mensagemService.Update(id, mensagemNova);
                    return Ok(mensagemNova);
                }

                return NoContent();
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return BadRequest("Erro ao fazer update da mensagem.");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id) {
            try {
                var mensagem = _mensagemService.Get(id);

                if (mensagem != null) {
                    _mensagemService.Remove(id);
                    return Ok(mensagem);
                }

                return NoContent();
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return BadRequest("Erro ao deletar mensagem.");
            }
        }
    }
}
