using Microsoft.AspNetCore.Mvc;
using Service.Services;
using System;
using System.Collections.Generic;

namespace Aplication.Controllers {

    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class MensagemPadraoController : ControllerBase {
        private readonly MensagemPadraoService _mensagemPadraoService;

        public MensagemPadraoController(MensagemPadraoService mensagemPadraoService) {
            _mensagemPadraoService = mensagemPadraoService;
        }

        [HttpGet("{unidade}")]
        public ActionResult<string> Get(string unidade) {
            try {
                var mensagemPadrao = _mensagemPadraoService.Get(unidade);

                if (mensagemPadrao != null) {
                    return Ok(mensagemPadrao);
                }

                return NoContent();
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return BadRequest("Erro ao buscar mensagem padrão por unidade.");
            }
        }

        [HttpPost("{unidade}")]
        public ActionResult Post([FromBody] List<string> mensagemPadrao, string unidade) {
            try {
                _mensagemPadraoService.Create(mensagemPadrao, unidade);

                return Ok(mensagemPadrao);
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return BadRequest("Erro ao salvar mensagem padrão.");
            }
        }

        [HttpPut("{unidade}")]
        public ActionResult<string> Put([FromBody] List<string> mensagemPadrao, string unidade) {
            try {
                var mensagemPadraoVelha = _mensagemPadraoService.Get(unidade);

                if (mensagemPadraoVelha != null) {
                    _mensagemPadraoService.Update(mensagemPadrao, unidade);
                    return Ok(mensagemPadrao);
                }

                return NoContent();
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return BadRequest("Erro ao fazer update da mensagem padrão.");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id) {
            try {
                var mensagemPadrao = _mensagemPadraoService.Get(id);

                if (mensagemPadrao != null) {
                    _mensagemPadraoService.Remove(id);
                    return Ok(mensagemPadrao);
                }

                return NoContent();
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return BadRequest("Erro ao deletar mensagem padrão.");
            }
        }
    }
}