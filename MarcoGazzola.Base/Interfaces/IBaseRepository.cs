using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarcoGazzola.Base.Interfaces
{
    public interface IBaseRepository<T> where T : IEntity
    {
        T CreateInstance();
        Task<IEnumerable<T>> GetAll();
        Task<T> GetByID(string id);
        Task<IInsertOperationResult> Add(T item);
        Task<IOperationResult> Remove(T item);
        Task RemoveAll();
        Task<IOperationResult> Update(T item);
        string CollectionName { get; }
    }
}
