using MongoDB.Driver;

namespace Infrastructure.Context {

    public class ContextDB : IContextDB {
        public string Connection { get; set; } = "mongodb://localhost:27017";
        public string Database { get; set; } = "chatway";

        public IMongoCollection<T> GetCollection<T>(string collection) {
            var client = new MongoClient(Connection);
            var database = client.GetDatabase(Database);
            return database.GetCollection<T>(collection);
        }
    }

    public interface IContextDB {
        string Connection { get; set; }
        string Database { get; set; }

        public IMongoCollection<T> GetCollection<T>(string collection);
    }
}