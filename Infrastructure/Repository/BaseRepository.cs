using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Infrastructure.Repository {

    public class BaseRepository<T> : IRepository<T> where T : BaseEntity {
        private readonly IMongoCollection<T> _collection;

        public BaseRepository(string collection) {
            _collection = new ContextDB().GetCollection<T>(collection);
        }

        public T Create(T obj) {
            _collection.InsertOne(obj);
            return obj;
        }

        public IList<T> Get() {
            return _collection.Find(u => true).ToList();
        }

        public T Get(string id) {
            return _collection.Find<T>(u => u.Id == id).FirstOrDefault();
        }

        public void Remove(string id) {
            _collection.DeleteOne(u => u.Id == id);
        }

        public void Update(string id, T obj) {
            _collection.ReplaceOne(u => u.Id == id, obj);
        }
    }
}