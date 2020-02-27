using Domain.Entities;
using Infrastructure.Context;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository {

    public class UnidadeRepository {
        private readonly IMongoCollection<Unidade> _unidade;

        public UnidadeRepository(ContextDB contextDB) {
            _unidade = contextDB.GetCollection<Unidade>("unidade");
        }

        public Unidade Create(Unidade unidade) {
            _unidade.InsertOne(unidade);
            return unidade;
        }

        public List<Unidade> Get() => _unidade.Find(u => true).ToList();

        public Unidade Get(string id) => _unidade.Find<Unidade>(u => u.Id == id).FirstOrDefault();

        public void Update(string id, Unidade unidade) => _unidade.ReplaceOne(u => u.Id == id, unidade);

        public void Remove(string id) => _unidade.DeleteOne(u => u.Id == id);
    }
}