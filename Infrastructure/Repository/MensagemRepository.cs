using Domain.Entities;
using Infrastructure.Context;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Infrastructure.Repository {

    public class MensagemRepository {
        private readonly IMongoCollection<Chat> _chat;

        public MensagemRepository(ContextDB contextDB) {
            _chat = contextDB.GetCollection<Chat>("chat");
        }

        public Mensagem Create(Mensagem mensagem) {
            mensagem.Id = ObjectId.GenerateNewId().ToString();

            var filter = Builders<Chat>.Filter.Where(x => x.Id == mensagem.Receiver);
            //var update = Builders<Chat>.Update.Push("Mensagens", mensagem);

            var update = Builders<Chat>.Update.PushEach(x => x.Mensagens, new List<Mensagem> { mensagem }, position: 0);

            //var update = Builders<Chat>.Update.Set(x => x.Mensagens[0], mensagem);

            var result = _chat.UpdateOneAsync(filter, update).Result;

            return mensagem;
        }

        public void UpdateItemTitle(Mensagem mensagem) {
            var filter = Builders<Chat>.Filter.Where(x => x.Id == mensagem.Receiver);
            var update = Builders<Chat>.Update.Push("Mensagens", mensagem);
            var result = _chat.UpdateOneAsync(filter, update).Result;
        }

        public List<Mensagem> Get(string chatId) {
            Chat chat = _chat.Find(u => u.Id == chatId).FirstOrDefault();
            return chat.Mensagens;
        }

        public Mensagem Get(string id, string chat) {
            var result = _chat.Find(u => u.Id == chat).FirstOrDefault();

            return result.Mensagens.Find(x => x.Id == id);
        }

        public void Update(string id, Mensagem mensagem) {
            _chat.Find<Chat>(chat => chat.Id == id).FirstOrDefault();
        }

        public void Remove(string id) => _chat.DeleteOne(u => u.Id == id);
    }
}