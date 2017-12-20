using MarcoGazzola.Base;
using MarcoGazzola.Base.Interfaces;
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

        public async Task<IInsertOperationResult> Add(T item)
        {
            try
            {
                item.CreatedOn = DateTime.Now;
                item.Id = null;
                await this.CollectionItems.InsertOneAsync(item);
                return new InsertOperationResult(item.Id, true);
            }
            catch (Exception ex)
            {
                return await new Task<IInsertOperationResult>(() => (IInsertOperationResult)ex.MongoException());
            }
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

        public async Task<IOperationResult> Remove(T item)
        {
            try
            {
                return (await this.CollectionItems.DeleteOneAsync(Builders<T>.Filter.Eq("Id", item.Id))).ToOperationResult();
            }
            catch (Exception ex)
            {
                return await new Task<IOperationResult>(() => ex.MongoException());
            }
        }

        public async Task RemoveAll()
        {
            await this.dbContext.database.DropCollectionAsync(this.CollectionName);
        }
        public async Task<IOperationResult> Update(T item)
        {
            try
            {
                var filter = Builders<T>.Filter.Eq(s => s.Id, item.Id);
                item.UpdatedOn = DateTime.Now;
                return (await this.CollectionItems.ReplaceOneAsync(filter, item)).ToOperationResult(); ;
            }
            catch (Exception ex)
            {
                return await new Task<IOperationResult>(() => ex.MongoException());
            }
        }
    }
}