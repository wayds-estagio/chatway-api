using Domain.Entities;
using Infrastructure.Repository;
using System.Collections.Generic;

namespace Service.Services {

    public class UnidadeService {
        private readonly UnidadeRepository _unidadeRepository;

        public UnidadeService(UnidadeRepository unidade) {
            this._unidadeRepository = unidade;
        }

        public List<Unidade> Get() {
            return _unidadeRepository.Get();
        }

        public Unidade Get(string id) {
            return _unidadeRepository.Get(id);
        }

        public void Create(Unidade unidade) {
            _unidadeRepository.Create(unidade);
        }

        public void Update(string id, Unidade unidade) {
            _unidadeRepository.Update(id, unidade);
        }

        public void Remove(string id) {
            _unidadeRepository.Remove(id);
        }
    }
}