using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Services;
using System;
using System.Collections.Generic;

namespace Aplication.Controllers {

    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase {
        private readonly EmpresaService _empresaService;

        public EmpresaController(EmpresaService empresaService) {
            _empresaService = empresaService;
        }

        [HttpGet]
        public ActionResult<List<Empresa>> Get() {
            try {
                return Ok(_empresaService.Get());
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return BadRequest("Erro ao buscar empresas.");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Usuario> Get(string id) {
            try {
                var empresa = _empresaService.Get(id);

                if (empresa != null) {
                    return Ok(empresa);
                }

                return NoContent();
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return BadRequest("Erro ao buscar empresa por id.");
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Empresa empresa) {
            try {
                _empresaService.Create(empresa);

                return Ok(empresa);
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return BadRequest("Erro ao salvar empresa.");
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Empresa> Put(string id, [FromBody] Empresa novaEmpresa) {
            try {
                var empresaVelha = _empresaService.Get(id);

                if (empresaVelha != null) {
                    _empresaService.Update(id, novaEmpresa);
                    return Ok(novaEmpresa);
                }

                return NoContent();
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return BadRequest("Erro ao fazer update da empresa.");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id) {
            try {
                var empresa = _empresaService.Get(id);

                if (empresa != null) {
                    _empresaService.Remove(id);
                    return Ok(empresa);
                }

                return NoContent();
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return BadRequest("Erro ao deletar empresa.");
            }
        }
    }
}