using Domain.Entities;
using Infrastructure.Repository;
using System.Collections.Generic;

namespace Service.Services {

    public class MensagemService {
        private readonly MensagemRepository _mensagemRepository;
        public readonly ChatRepository _chatRepository;

        public MensagemService(MensagemRepository mensagem) {
            this._mensagemRepository = mensagem;
        }

        public List<Mensagem> Get() {
            return _mensagemRepository.Get();
        }

        public Mensagem Get(string id) {
            return _mensagemRepository.Get(id);
        }

        public void Create(Mensagem mensagem) {
            _mensagemRepository.Create(mensagem);
        }

        public void Update(string id, Mensagem mensagem) {
            _mensagemRepository.Update(id, mensagem);
        }

        public void Remove(string id) {
            _mensagemRepository.Remove(id);
        }
    }
}