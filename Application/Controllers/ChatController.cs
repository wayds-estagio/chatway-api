using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Services;
using System;
using System.Collections.Generic;

namespace Aplication.Controllers {

    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ChatController : ControllerBase {
        private readonly ChatService _chatService;

        public ChatController(ChatService chatService) {
            _chatService = chatService;
        }

        [HttpGet]
        public ActionResult<List<Chat>> Get() {
            try {
                return Ok(_chatService.Get());
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return BadRequest("Erro ao buscar chats.");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Chat> Get(string id) {
            try {
                var chat = _chatService.Get(id);

                if (chat != null) {
                    return Ok(chat);
                }

                return NoContent();
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return BadRequest("Erro ao buscar chat por id.");
            }
        }

        [HttpGet("pendentes/{unidade}")]
        public ActionResult<List<Chat>> GetPendentes(string unidade) {
            try {
                return Ok(_chatService.GetPendentes(unidade));
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return BadRequest("Erro ao buscar chats pendentes.");
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Chat chat) {
            try {
                _chatService.Create(chat);

                return Ok(chat);
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return BadRequest("Erro ao salvar chat.");
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Chat> Put(string id, [FromBody] Chat chatNovo) {
            try {
                var chatVelho = _chatService.Get(id);

                if (chatVelho != null) {
                    _chatService.Update(id, chatNovo);
                    return Ok(chatNovo);
                }

                return NoContent();
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return BadRequest("Erro ao fazer update da chat.");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id) {
            try {
                var chat = _chatService.Get(id);

                if (chat != null) {
                    _chatService.Remove(id);
                    return Ok(chat);
                }

                return NoContent();
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return BadRequest("Erro ao deletar chat.");
            }
        }
    }
}