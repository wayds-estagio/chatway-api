using Domain.Entities;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;

namespace Service.Services {

    public class ChatService {
        private readonly ChatRepository _chatRepository;

        public ChatService(ChatRepository chatRepository) {
            this._chatRepository = chatRepository;
        }

        public List<Chat> Get() {
            return _chatRepository.Get();
        }

        public Chat Get(string id) {
            return _chatRepository.Get(id);
        }

        public List<Chat> GetPendentes(string unidade) {
            //List<Chat> listChats = new List<Chat> {
            //    new Chat {
            //        Atendente = "Atendente",
            //        Concluido = false,
            //        Motorista = "Motorista",
            //        Unidade = unidade,
            //        DataCriacao = DateTime.Now
            //    }
            //};

            //return listChats;
            return _chatRepository.GetPendentes(unidade);
        }

        public void Create(Chat chat) {
            chat.DataCriacao = DateTime.Now;
            if (chat.Mensagens == null)
                chat.Mensagens = new List<Mensagem>();
            _chatRepository.Create(chat);
        }

        public void Update(string id, Chat chat) {
            _chatRepository.Update(id, chat);
        }

        public void Remove(string id) {
            _chatRepository.Remove(id);
        }
    }
}
