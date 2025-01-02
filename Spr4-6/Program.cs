using MongoDB.Bson;
using MongoDB.Driver;
using Spr.Mongo;
using Spr.ObjectDB;
using Spr.SqlServer;

namespace Spr4_6;

/// <summary>
/// 
/// </summary>
internal class Program
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var mongo = new MongodbConnection();
        mongo.Connect();
        var sqlserver = new SqlServerConection();
        sqlserver.Connect();
        var objectDB = new ObjectDBConnection();
        objectDB.Test();

        Console.WriteLine("Bye, World!");

    }
}
