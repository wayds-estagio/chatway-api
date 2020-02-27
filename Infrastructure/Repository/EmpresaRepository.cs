using Domain.Entities;
using Infrastructure.Context;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Infrastructure.Repository {

    public class EmpresaRepository {
        private readonly IMongoCollection<Empresa> _empresa;

        public EmpresaRepository(ContextDB contextDB) {
            _empresa = contextDB.GetCollection<Empresa>("empresa");
        }

        public Empresa Create(Empresa empresa) {
            _empresa.InsertOne(empresa);
            return empresa;
        }

        public List<Empresa> Get() => _empresa.Find(u => true).ToList();

        public Empresa Get(string id) => _empresa.Find<Empresa>(u => u.Id == id).FirstOrDefault();

        public void Update(string id, Empresa empresa) => _empresa.ReplaceOne(u => u.Id == id, empresa);

        public void Remove(string id) => _empresa.DeleteOne(u => u.Id == id);
    }
}