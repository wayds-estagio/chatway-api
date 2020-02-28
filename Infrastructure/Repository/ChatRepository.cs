using Domain.Entities;
using Infrastructure.Context;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository {

    public class ChatRepository {
        private readonly IMongoCollection<Chat> _chat;

        public ChatRepository(ContextDB contextDB) {
            _chat = contextDB.GetCollection<Chat>("chat");
        }

        public void Create(Chat chat) {
            _chat.InsertOne(chat);
        }

        public List<Chat> Get() => _chat.Find(u => true).ToList();

        public Chat Get(string id) => _chat.Find<Chat>(u => u.Id == id).FirstOrDefault();

        public Chat GetPendente() {
            FilterDefinition<Chat> filtro = Builders<Chat>.Filter.Where(e => e.Atendente == null);
            return _chat.Find<Chat>(filtro).FirstOrDefault();
        }

        public void Update(string id, Chat chat) => _chat.ReplaceOne(u => u.Id == id, chat);

        public void Remove(string id) => _chat.DeleteOne(u => u.Id == id);
    }
}