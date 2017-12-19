using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarcoGazzola.MongoDB.Interfaces
{
    public interface IBaseRepository<T> where T : IEntity
    {
        T CreateInstance();
        Task<IEnumerable<T>> GetAll();
        Task<T> GetByID(string id);
        Task Add(T item);
        Task<DeleteResult> Remove(T item);
        Task RemoveAll();
        Task<ReplaceOneResult> Update(T item);
        string CollectionName { get; }
    }
}
