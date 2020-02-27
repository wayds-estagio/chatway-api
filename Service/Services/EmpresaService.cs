using Domain.Entities;
using Infrastructure.Repository;
using System.Collections.Generic;

namespace Service.Services {

    public class EmpresaService {
        private readonly EmpresaRepository _empresaRepository;

        public EmpresaService(EmpresaRepository empresa) {
            this._empresaRepository = empresa;
        }

        public List<Empresa> Get() {
            return _empresaRepository.Get();
        }

        public Empresa Get(string id) {
            return _empresaRepository.Get(id);
        }

        public void Create(Empresa empresa) {
            _empresaRepository.Create(empresa);
        }

        public void Update(string id, Empresa empresa) {
            _empresaRepository.Update(id, empresa);
        }

        public void Remove(string id) {
            _empresaRepository.Remove(id);
        }
    }
}