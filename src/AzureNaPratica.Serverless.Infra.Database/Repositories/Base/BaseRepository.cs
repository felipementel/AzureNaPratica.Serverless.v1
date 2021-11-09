using AzureNaPratica.Serverless.Domain.Base.Entity;
using AzureNaPratica.Serverless.Domain.Base.Interfaces.Repository;
using AzureNaPratica.Serverless.Domain.Base.Interfaces.Repository.MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureNaPratica.Serverless.Infra.Database.Repositories.Base
{
    public abstract class BaseRepository<TEntity, Tid>
        : IBaseRepository<TEntity, Tid> where TEntity : BaseEntityId<Tid>
    {
        public readonly IMongoCollection<TEntity> _collection;

        protected BaseRepository(IMongoDbContext context, string collectionName) =>
            _collection = context.GetCollection<TEntity>(collectionName);


        public async virtual Task DeleteAsync(Tid id) =>
            await _collection.DeleteOneAsync(Builders<TEntity>.Filter.Eq(t => t.Id, id));

        public async virtual Task<IList<TEntity>> FindAllAsync()
        {
            var all = await _collection.FindAsync(new BsonDocument());

            return await all.ToListAsync();
        }

        public async virtual Task<TEntity> FindByIdAsync(Tid id)
        {
            FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq(t => t.Id, id);

            return await _collection.FindAsync(filter).Result.FirstOrDefaultAsync();
        }

        public async virtual Task InsertAsync(TEntity entity) =>
            await _collection.InsertOneAsync(entity);

        public async virtual Task UpdateAsync(TEntity entity)
        {
            var filter = Builders<TEntity>.Filter.Eq(t => t.Id, entity.Id);
            await _collection.ReplaceOneAsync(filter, entity);
        }
    }
}