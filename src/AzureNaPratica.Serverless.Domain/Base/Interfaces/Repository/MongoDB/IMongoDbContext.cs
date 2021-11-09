using MongoDB.Driver;

namespace AzureNaPratica.Serverless.Domain.Base.Interfaces.Repository.MongoDB
{
    public interface IMongoDbContext
    {
        IMongoCollection<TEntity> GetCollection<TEntity>(string collectionName);
    }
}