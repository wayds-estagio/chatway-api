using Domain.Entities;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;

namespace Service.Services {

    public class MensagemService {
        private readonly MensagemRepository _mensagemRepository;
        public readonly ChatRepository _chatRepository;

        public MensagemService(MensagemRepository mensagem) {
            this._mensagemRepository = mensagem;
        }

        public List<Mensagem> Get(string chat) {
            return _mensagemRepository.Get(chat);
        }

        public Mensagem Get(string id, string chat) {
            return _mensagemRepository.Get(id, chat);
        }

        public void Create(Mensagem mensagem) {
            mensagem.Time = DateTime.Now;
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
