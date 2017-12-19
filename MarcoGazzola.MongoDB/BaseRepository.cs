using MarcoGazzola.MongoDB.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarcoGazzola.MongoDB
{
    public class BaseRepository<T> : IBaseRepository<T> where T : IEntity
    {
        public readonly IDBContext dbContext;
        public BaseRepository(IDBContext dbContext, string CollectionName)
        {
            this.dbContext = dbContext;
            this.CollectionItems = dbContext.database.GetCollection<T>(CollectionName);
            this.CollectionName = CollectionName;
        }

        private IMongoCollection<T> CollectionItems { get; }

        public string CollectionName { get; }

        public async Task Add(T item)
        {
            item.CreatedOn = DateTime.Now;
            item.Id = null;
            await this.CollectionItems.InsertOneAsync(item);
        }

        public T CreateInstance()
        {
            return (T)Activator.CreateInstance(typeof(T));
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await this.CollectionItems.Find(_ => true).ToListAsync();
        }

        public async Task<T> GetByID(string id)
        {
            return await this.CollectionItems.Find(item => item.Id == id).FirstOrDefaultAsync<T>();
        }

        public async Task<DeleteResult> Remove(T item)
        {
            return await this.CollectionItems.DeleteOneAsync(Builders<T>.Filter.Eq("Id", item.Id));
        }

        public async Task RemoveAll()
        {
            await this.dbContext.database.DropCollectionAsync(this.CollectionName);
        }
        public async Task<ReplaceOneResult> Update(T item)
        {
            var filter = Builders<T>.Filter.Eq(s => s.Id, item.Id);
            item.UpdatedOn = DateTime.Now;
            return await this.CollectionItems.ReplaceOneAsync(filter, item);
        }
    }
}