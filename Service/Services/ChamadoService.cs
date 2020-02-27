using Domain.Entities;
using Infrastructure.Repository;
using System.Collections.Generic;

namespace Service.Services {

    public class ChamadoService {
        private readonly ChamadoRepository _chamadoRepository;

        public ChamadoService(ChamadoRepository chamado) {
            this._chamadoRepository = chamado;
        }

        public List<Chamado> Get() {
            return _chamadoRepository.Get();
        }

        public Chamado Get(string id) {
            return _chamadoRepository.Get(id);
        }

        public void Create(Chamado chamado) {
            _chamadoRepository.Create(chamado);
        }

        public void Update(string id, Chamado chamado) {
            _chamadoRepository.Update(id, chamado);
        }

        public void Remove(string id) {
            _chamadoRepository.Remove(id);
        }
    }
}