using MarcoGazzola.MongoDB.Interfaces;
using MongoDB.Driver;

namespace MarcoGazzola.MongoDB
{
    public class MongoDbContext : IDBContext
    {
        public IMongoDatabase database { get; }

        public MongoDbContext(string ConnectionString, string Database)
        {
            var client = new MongoClient(ConnectionString);
            if (client != null)
                database = client.GetDatabase(Database);
        }
    }
}