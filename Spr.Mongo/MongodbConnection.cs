using MongoDB.Bson;
using MongoDB.Driver;
using Spr.Core;

namespace Spr.Mongo;

public class MongodbConnection: BaseConnection<MongoClient>
{
    public override void Connect()
    {
        var connectionString = Environment.GetEnvironmentVariable("MONGODB_URI");
        if (connectionString == null)
        {
            Console.WriteLine("You must set your 'MONGODB_URI' environment variable. To learn how to set it, see https://www.mongodb.com/docs/drivers/csharp/current/quick-start/#set-your-connection-string");
            Environment.Exit(0);
        }

        this._client = new MongoClient(connectionString);
    }


    public void Test()
    {
        var connectionString = Environment.GetEnvironmentVariable("MONGODB_URI");
        if (connectionString == null)
        {
            Console.WriteLine("You must set your 'MONGODB_URI' environment variable. To learn how to set it, see https://www.mongodb.com/docs/drivers/csharp/current/quick-start/#set-your-connection-string");
            Environment.Exit(0);
        }

        var client = new MongoClient(connectionString);
        var collection = client.GetDatabase("test").GetCollection<BsonDocument>("movies");
        var filter = Builders<BsonDocument>.Filter.Eq("title", "Back to the Future");
        var document = collection.Find(filter).First();
        Console.WriteLine(document);
    }
}
