using Domain.Entities;
using Infrastructure.Context;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Infrastructure.Repository {

    public class MensagemRepository {
        private readonly IMongoCollection<Mensagem> _mensagem;

        public MensagemRepository(ContextDB contextDB) {
            _mensagem = contextDB.GetCollection<Mensagem>("mensagem");
        }

        public Mensagem Create(Mensagem mensagem) {
            _mensagem.InsertOne(mensagem);
            return mensagem;
        }

        public List<Mensagem> Get() => _mensagem.Find(u => true).ToList();

        public Mensagem Get(string id) => _mensagem.Find<Mensagem>(u => u.Id == id).FirstOrDefault();

        public void Update(string id, Mensagem mensagem) => _mensagem.ReplaceOne(u => u.Id == id, mensagem);

        public void Remove(string id) => _mensagem.DeleteOne(u => u.Id == id);
    }
}