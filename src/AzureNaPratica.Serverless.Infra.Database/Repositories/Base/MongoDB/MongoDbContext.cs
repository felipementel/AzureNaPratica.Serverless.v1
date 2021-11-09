using AzureNaPratica.Serverless.Domain.Base.Interfaces.Repository.MongoDB;
using AzureNaPratica.Serverless.Domain.Configs;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Security.Authentication;

namespace AzureNaPratica.Serverless.Infra.Database.Repositories.Base.MongoDB
{
    public class MongoDbContext : IMongoDbContext
    {
        private readonly IMongoDatabase _mongoDatabase;

        public MongoDbContext(
            IOptions<ConnectionStrings> connectionStrings,
            IOptions<ApplicationSettings> applicationSettings)
        {
            MongoClientSettings settings = MongoClientSettings.FromUrl(
              new MongoUrl(connectionStrings.Value.MongoDbConnectionString));

            settings.SslSettings =
              new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            MongoClient mongoClient = new (settings);

            this._mongoDatabase = mongoClient.GetDatabase(applicationSettings.Value.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return this._mongoDatabase.GetCollection<T>(collectionName);
        }
    }
}