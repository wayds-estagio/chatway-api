using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Services;
using System;
using System.Collections.Generic;

namespace Aplication.Controllers {

    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FraseAjudaController : ControllerBase {
        private readonly FraseAjudaService _fraseAjudaService;

        public FraseAjudaController(FraseAjudaService fraseAjudaService) {
            _fraseAjudaService = fraseAjudaService;
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(string id) {
            try {
                var fraseAjuda = _fraseAjudaService.Get(id);

                if (fraseAjuda != null) {
                    return Ok(fraseAjuda);
                }

                return NoContent();
            } catch (Exception ex) {
                Console.WriteLine(ex);
                return BadRequest("Erro ao buscar frase ajuda por id.");
            }
        }

        [HttpPost("{unidade}")]
        public ActionResult Post([FromBody] FraseAjuda fraseAjuda, string unidade) {
            try {
                _fraseAjudaService.Create(fraseAjuda, unidade);

                return Ok(fraseAjuda);
            } catch (Exception ex) {
                Console.WriteLine(ex);
                return BadRequest("Erro ao salvar fraseAjuda.");
            }
        }

        [HttpPut("{id}")]
        public ActionResult<string> Put(string id, [FromBody] string fraseAjudaNova) {
            try {
                var fraseAjudaVelha = _fraseAjudaService.Get(id);

                if (fraseAjudaVelha != null) {
                    _fraseAjudaService.Update(id, fraseAjudaNova);
                    return Ok(fraseAjudaNova);
                }

                return NoContent();
            } catch (Exception ex) {
                Console.WriteLine(ex);
                return BadRequest("Erro ao fazer update da frase ajuda.");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id) {
            try {
                var fraseAjuda = _fraseAjudaService.Get(id);

                if (fraseAjuda != null) {
                    _fraseAjudaService.Remove(id);
                    return Ok(fraseAjuda);
                }

                return NoContent();
            } catch (Exception ex) {
                Console.WriteLine(ex);
                return BadRequest("Erro ao deletar frase ajuda.");
            }
        }
    }
}