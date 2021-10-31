using System;
using Beer.API.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Beer.API.Data
{
    public class MongoDbContext
    {
        private readonly IOptions<DatabaseSettings> _dbSettings;
        private readonly IMongoDatabase _mongoDb;

        public MongoDbContext(
            IOptions<DatabaseSettings> dbSettings,
            IMongoClient mongoClient)
        {
            _dbSettings = dbSettings 
                ?? throw new ArgumentNullException(nameof(mongoClient));

            _mongoDb = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
        }

        public IMongoCollection<Entities.Beer> Beers =>
            _mongoDb.GetCollection<Entities.Beer>(_dbSettings.Value.CollectionName);
    }
}