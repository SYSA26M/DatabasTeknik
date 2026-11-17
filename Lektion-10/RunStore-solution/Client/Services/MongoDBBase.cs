using System;
using MongoDB.Driver;

namespace Client.Services;

public class MongoDBBase<T> : BaseService
{
    protected IMongoCollection<T> GetCollection(string database, string collection)
    {
        var client = new MongoClient(ConnectionString);
        return client.GetDatabase(database).GetCollection<T>(collection);
    }
}
