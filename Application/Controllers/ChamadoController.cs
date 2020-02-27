using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Services;
using System;
using System.Collections.Generic;

namespace Aplication.Controllers {

    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ChamadoController : ControllerBase {
        private readonly ChamadoService _chamadoService;

        public ChamadoController(ChamadoService chamadoService) {
            _chamadoService = chamadoService;
        }

        [HttpGet]
        public ActionResult<List<Chamado>> Get() {
            try {
                return Ok(_chamadoService.Get());
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return BadRequest("Erro ao buscar chamados.");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Chamado> Get(string id) {
            try {
                var chamado = _chamadoService.Get(id);

                if (chamado != null) {
                    return Ok(chamado);
                }

                return NoContent();
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return BadRequest("Erro ao buscar chamado por id.");
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Chamado chamado) {
            try {
                _chamadoService.Create(chamado);

                return Ok(chamado);
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return BadRequest("Erro ao salvar chamado.");
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Chamado> Put(string id, [FromBody] Chamado chamadoNovo) {
            try {
                var chamadoVelho = _chamadoService.Get(id);

                if (chamadoVelho != null) {
                    _chamadoService.Update(id, chamadoNovo);
                    return Ok(chamadoNovo);
                }

                return NoContent();
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return BadRequest("Erro ao fazer update da chamado.");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id) {
            try {
                var chamado = _chamadoService.Get(id);

                if (chamado != null) {
                    _chamadoService.Remove(id);
                    return Ok(chamado);
                }

                return NoContent();
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return BadRequest("Erro ao deletar chamado.");
            }
        }
    }
}