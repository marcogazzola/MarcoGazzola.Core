using MongoDB.Driver;

namespace MarcoGazzola.MongoDB.Interfaces
{
    public interface IDBContext
    {
        IMongoDatabase database { get; }
    }
}