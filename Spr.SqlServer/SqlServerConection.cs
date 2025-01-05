using Spr.Core;
using Spr.SqlServer.Models;
using System.Diagnostics;

namespace Spr.SqlServer;

public class SqlServerConection : BaseConnection<TestContext>
{
    public override void Connect()
    {
        this._client = new TestContext();

        var sw = new Stopwatch();

        for (int recordCount = 1; recordCount <= 6; recordCount++)
        {
            var objList = new List<CategoryRecord>();
            for (int i = 0; i < Math.Pow(10, recordCount); i++)
            {
                objList.Add(new CategoryRecord(Guid.NewGuid().ToString(), Guid.NewGuid().ToString()));
              //  objList.Add(new CategoryRecord(i, Guid.NewGuid().ToString(), Guid.NewGuid().ToString()));
            }

            // create
            sw.Restart();
            this._client.Category.AddRange(objList);
            this._client.SaveChanges();
            sw.Stop();

            Console.WriteLine($"Time to insert {Math.Pow(10, recordCount)} records: {sw.ElapsedMilliseconds} ms");

            // read
            sw.Restart();
            var records = this._client.Category.ToList();
            sw.Stop();

            Console.WriteLine($"Time to read {Math.Pow(10, recordCount)} records: {sw.ElapsedMilliseconds} ms");

            // delete
            sw.Restart();
            this._client.Category.RemoveRange(objList);
            this._client.SaveChanges();
            sw.Stop();

            Console.WriteLine($"Time to delete {Math.Pow(10, recordCount)} records: {sw.ElapsedMilliseconds} ms");

            objList.Clear();
        }
    }
}
