using MongoDB.Bson;
using MongoDB.Driver;
using Spr.Mongo;
using Spr.ObjectDB;
using Spr.Oracle;
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

        try
        {
            Console.WriteLine("\nTesting Oracle.");
            var oracleDB = new OracleDBConnection();
            oracleDB.Connect();
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            Console.WriteLine("\nTesting MongoDB.");
            var mongo = new MongodbConnection();
            mongo.Connect();
            mongo.Test();
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            Console.WriteLine("\nTesting Sql server.");
            var sqlserver = new SqlServerConection();
            sqlserver.Connect();
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            Console.WriteLine("\nTesting Db4o DB.");
            var objectDB = new ObjectDBConnection();
            objectDB.Test();
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("\nBye, World!");

    }
}
