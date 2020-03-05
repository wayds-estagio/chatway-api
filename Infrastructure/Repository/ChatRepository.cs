using Domain.Entities;
using Infrastructure.Context;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository {

    public class ChatRepository {
        private readonly IMongoCollection<Chat> _chat;

        public ChatRepository(ContextDB contextDB) {
            _chat = contextDB.GetCollection<Chat>("chat");
        }

        public void Create(Chat chat) => _chat.InsertOne(chat);

        public List<Chat> Get() => _chat.Find(u => true).ToList();

        public Chat Get(string id) => _chat.Find(chat => chat.Id == id).FirstOrDefault();

        public Chat GetLastChat() => _chat.Find(u => true).FirstOrDefault();

        public List<Chat> GetPendentes(string unidade) {
            FilterDefinition<Chat> filtro = Builders<Chat>.Filter.Where(chat => chat.Atendente == null && chat.Unidade == unidade);

            return _chat.Find(filtro).ToList();
        }

        public List<Chat> GetAtendidos(string unidade, string atendente) {
            FilterDefinition<Chat> filtro = Builders<Chat>.Filter.Where(chat => chat.AtendenteId == atendente && chat.Unidade == unidade);

            return _chat.Find(filtro).ToList();
        }
        public Chat UpdateAtendente(string id, Usuario atendente) {
            Chat newChat = _chat.Find(chat => chat.Id == id).FirstOrDefault();

            newChat.Atendente = atendente.Nome;
            newChat.AtendenteId = atendente.Id;

            _chat.ReplaceOne(chat => chat.Id == id, newChat);

            return newChat;
        }

        public void Update(string id, Chat chat) => _chat.ReplaceOne(chat => chat.Id == id, chat);

        public void Remove(string id) => _chat.DeleteOne(chat => chat.Id == id);
    }
}
