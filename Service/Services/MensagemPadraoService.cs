using Domain.Entities;
using Infrastructure.Repository;
using System.Collections.Generic;

namespace Service.Services {

    public class MensagemPadraoService {
        private readonly UnidadeRepository _unidadeRepository;

        public MensagemPadraoService(UnidadeRepository unidadeRepository) {
            this._unidadeRepository = unidadeRepository;
        }

        public List<string> Get(string unidadeId) {
            Unidade unidade = _unidadeRepository.Get(unidadeId);
            List<string> mensagemPadrao = unidade.MensagemPadrao;

            return mensagemPadrao;
        }

        public void Create(List<string> mensagemPadrao, string unidadeId) {
            Unidade unidade = _unidadeRepository.Get(unidadeId);
            unidade.MensagemPadrao = mensagemPadrao;

            _unidadeRepository.Update(unidadeId, unidade);
        }

        public void Update(List<string> mensagemPadrao, string unidadeId) {
            Unidade unidade = _unidadeRepository.Get(unidadeId);
            unidade.MensagemPadrao = mensagemPadrao;

            _unidadeRepository.Update(unidadeId, unidade);
        }

        public void Remove(string unidadeId) {
            Unidade unidade = _unidadeRepository.Get(unidadeId);
            unidade.MensagemPadrao.Clear();

            _unidadeRepository.Update(unidadeId, unidade);
        }
    }
}