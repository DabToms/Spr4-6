using MongoDB.Bson;
using MongoDB.Driver;
using Spr.Core;
using Spr.Mongo.Models;
using System.Diagnostics;

namespace Spr.Mongo;

public class MongodbConnection : BaseConnection<MongoClient>
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
        var collection = client.GetDatabase("test").GetCollection<CategoryDocument>("Categories");

        var sw = new Stopwatch();
        for (int recordCount = 1; recordCount <= 6; recordCount++)
        {
            var categories = new List<CategoryDocument>();
            for (int i = 0; i < Math.Pow(10, recordCount); i++)
            {
                categories.Add(new CategoryDocument() { Name = Guid.NewGuid().ToString(), Description = Guid.NewGuid().ToString() });
            }

            // create
            sw.Restart();
            collection.InsertMany(categories);
            sw.Stop();

            Console.WriteLine($"Time to insert {Math.Pow(10, recordCount)} records: {sw.ElapsedMilliseconds} ms");

            // read
            sw.Restart();

            var filter = Builders<CategoryDocument>.Filter.Empty;
            var document = collection.Find(filter);
            foreach (var doc in document.ToEnumerable())
            {
                // do something
            }

            sw.Stop();

            Console.WriteLine($"Time to read {Math.Pow(10, recordCount)} records: {sw.ElapsedMilliseconds} ms");

            // delete
            sw.Restart();
            var result = collection.DeleteMany(filter);
            sw.Stop();

            Console.WriteLine($"Time to delete {Math.Pow(10, recordCount)} records: {sw.ElapsedMilliseconds} ms");

            categories.Clear();
        }
    }
}
