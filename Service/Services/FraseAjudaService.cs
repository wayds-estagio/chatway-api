using Domain.Entities;
using Infrastructure.Repository;
using System.Collections.Generic;

namespace Service.Services {

    public class FraseAjudaService {
        private readonly UnidadeRepository _unidadeRepository;

        public FraseAjudaService(UnidadeRepository unidadeRepository) {
            this._unidadeRepository = unidadeRepository;
        }

        public FraseAjuda Get(string unidadeId) {
            Unidade unidade = _unidadeRepository.Get(unidadeId);

            FraseAjuda fraseAjuda = new FraseAjuda();
            fraseAjuda.PrecisoAjuda = unidade.PrecisoAjuda;

            return fraseAjuda;
            //return _unidadeRepository.Get(id);
        }

        public void Create(FraseAjuda fraseAjuda, string unidadeId) {
            Unidade unidade = _unidadeRepository.Get(unidadeId);

            unidade.PrecisoAjuda = fraseAjuda.PrecisoAjuda;

            _unidadeRepository.Update(unidadeId, unidade);
        }

        public void Update(string id, string mensagem) {
            //_unidadeRepository.Update(id, mensagem);
        }

        public void Remove(string id) {
            _unidadeRepository.Remove(id);
        }
    }
}