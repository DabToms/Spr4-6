using Microsoft.EntityFrameworkCore;
using Spr.Core;
using Spr.SqlServer.Models;
using System.Diagnostics;

namespace Spr.SqlServer;

public class SqlServerConection : BaseConnection<SqlServerContext>
{

    public SqlServerConection()
        : base("Sql Server")
    {
        this._client = new SqlServerContext();
    }

    /// <inheritdoc />
    protected override IEnumerable<object> CreateSamples(int count)
    {
        var categories = new List<CategoryRecord>();
        for (int i = 1; i <= count; i++)
        {
            categories.Add(new CategoryRecord(i, Guid.NewGuid().ToString(), Guid.NewGuid().ToString()));
        }

        return categories;
    }

    /// <inheritdoc />
    protected override void TestInsert(IEnumerable<object> samples)
    {
        this._client.Category.AddRange((IEnumerable<CategoryRecord>)samples);
        this._client.SaveChanges();
    }

    /// <inheritdoc />
    protected override void TestReadAll()
    {
        this._client.Category.ToList();
    }

    /// <inheritdoc />
    protected override void TestUpdate(IEnumerable<object> samples)
    {
        this._client.Category.ExecuteUpdate(x => x.SetProperty(p => p.Description, "Test update"));
        this._client.SaveChanges();
    }

    /// <inheritdoc />
    protected override void TestDelete(IEnumerable<object> samples)
    {
        this._client.Category.RemoveRange((IEnumerable<CategoryRecord>)samples);
        this._client.SaveChanges();
    }



    /// <inheritdoc />
    public override void TestOperation()
    {
        this._client = new SqlServerContext();

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

    protected override void TestReadFiltered(object obj)
    {
        this._client.Category.Where(x => x.Name == ((CategoryRecord)obj).Name).ToList();
    }

    protected override void CreateIndex()
    {
        this._client.Database.ExecuteSqlRaw("CREATE INDEX IX_CATEGORY_NAME ON Category(Name)");
    }

    protected override void DropIndexes()
    {
        this._client.Database.ExecuteSqlRaw("DROP INDEX IX_CATEGORY_NAME ON Category");
    }
}
