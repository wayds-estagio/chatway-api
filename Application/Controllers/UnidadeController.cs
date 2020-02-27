using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Services;
using System;
using System.Collections.Generic;

namespace ChatWay.Controllers {

    [Route("api/v1/[controller]")]
    [ApiController]
    public class UnidadeController : ControllerBase {
        private readonly UnidadeService _unidadeService;

        public UnidadeController(UnidadeService unidadeService) {
            _unidadeService = unidadeService;
        }

        [HttpGet]
        public ActionResult<List<Unidade>> Get() {
            try {
                return Ok(_unidadeService.Get());
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return BadRequest("Erro ao buscar unidades.");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Usuario> Get(string id) {
            try {
                var unidade = _unidadeService.Get(id);

                if (unidade != null) {
                    return Ok(unidade);
                }

                return NoContent();
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return BadRequest("Erro ao buscar unidade por id.");
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Unidade unidade) {
            try {
                _unidadeService.Create(unidade);

                return Ok(unidade);
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return BadRequest("Erro ao salvar unidade.");
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Unidade> Put(string id, [FromBody] Unidade novaUnidade) {
            try {
                var unidadeVelha = _unidadeService.Get(id);

                if (unidadeVelha != null) {
                    _unidadeService.Update(id, novaUnidade);
                    return Ok(novaUnidade);
                }

                return NoContent();
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return BadRequest("Erro ao fazer update da unidade.");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id) {
            try {
                var unidade = _unidadeService.Get(id);

                if (unidade != null) {
                    _unidadeService.Remove(id);
                    return Ok(unidade);
                }

                return NoContent();
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return BadRequest("Erro ao deletar unidade.");
            }
        }
    }
}