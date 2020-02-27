using Domain.Entities;
using Infrastructure.Repository;
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

        public Chat GetPendente() {
            return _chatRepository.GetPendente();
        }

        public void Create(Chat chat) {
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