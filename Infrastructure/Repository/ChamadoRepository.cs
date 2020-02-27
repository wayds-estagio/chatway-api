using Domain.Entities;
using Infrastructure.Context;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Infrastructure.Repository {

    public class ChamadoRepository {
        private readonly IMongoCollection<Chamado> _chamado;

        public ChamadoRepository(ContextDB contextDB) {
            _chamado = contextDB.GetCollection<Chamado>("chamado");
        }

        public Chamado Create(Chamado chamado) {
            _chamado.InsertOne(chamado);
            return chamado;
        }

        public List<Chamado> Get() => _chamado.Find(u => true).ToList();

        public Chamado Get(string id) => _chamado.Find<Chamado>(u => u.Id == id).FirstOrDefault();

        public void Update(string id, Chamado chamado) => _chamado.ReplaceOne(u => u.Id == id, chamado);

        public void Remove(string id) => _chamado.DeleteOne(u => u.Id == id);
    }
}