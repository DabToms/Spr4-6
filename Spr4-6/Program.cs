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
        Console.WriteLine("Testing database operations.");
        var tasks = new List<Task>();
        try
        {
            var objectDB = new ObjectDBConnection();
            tasks.Add(Task.Factory.StartNew(new Action(() => { objectDB.TestOperations(); })));
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            var mongo = new MongodbConnection();
            tasks.Add(Task.Factory.StartNew(new Action(() => { mongo.TestOperations(); })));
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            var sqlserver = new SqlServerConection();
            tasks.Add(Task.Factory.StartNew(new Action(() => { sqlserver.TestOperations(); })));
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            var oracleDB = new OracleDBConnection();
            tasks.Add(Task.Factory.StartNew(new Action(() => { oracleDB.TestOperations(); })));
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        tasks.ForEach(t => t.Wait());

        Console.WriteLine("\nBye, World!");

    }
}
