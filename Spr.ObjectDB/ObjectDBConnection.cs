using Db4objects.Db4o;
using Spr.Core;
using Spr.ObjectDB.Models;
using System;
using System.Diagnostics;

namespace Spr.ObjectDB;

public class ObjectDBConnection : BaseConnection<IObjectContainer>
{
    public ObjectDBConnection()
        : base("Db4o")
    {
        this._client = Db4oFactory.OpenFile($"{Guid.NewGuid().ToString()}.data");
    }

    /// <inheritdoc />
    protected override IEnumerable<object> CreateSamples(int count)
    {
        var categories = new List<Category>();
        for (int i = 0; i < count; i++)
        {
            categories.Add(new Category(i, Guid.NewGuid().ToString(), Guid.NewGuid().ToString()));
        }

        return categories;
    }

    /// <inheritdoc />
    protected override void TestInsert(IEnumerable<object> samples)
    {
        foreach (var cat in samples)
        {
            this._client.Store(cat);
        }

        this._client.Commit();
    }

    /// <inheritdoc />
    protected override void TestReadAll()
    {
        var itemsQuery = this._client.Query<Category>();
    }

    /// <inheritdoc />
    protected override void TestReadFiltered(object obj)
    {
        var itemsQuery = this._client.Query<Category>(x => x.Name == ((Category)obj).Name);
    }

    /// <inheritdoc />
    protected override void TestUpdate(IEnumerable<object> samples)
    {
        foreach (var cat in samples)
        {
            ((Category)cat).Description = "Test update";
            this._client.Store(cat);
        }

        this._client.Commit();
    }

    /// <inheritdoc />
    protected override void TestDelete(IEnumerable<object> samples)
    {
        foreach (var cat in samples)
        {
            this._client.Delete(cat);
        }

        this._client.Commit();
    }


    public void Test()
    {
        using (IObjectContainer db = Db4oEmbedded.OpenFile($"{Guid.NewGuid().ToString()}.data"))
        {
            var sw = new Stopwatch();

            for (int recordCount = 1; recordCount <= 6; recordCount++)
            {
                var objList = new List<Category>();
                for (int i = 0; i < Math.Pow(10, recordCount); i++)
                {
                    objList.Add(new Category(i, Guid.NewGuid().ToString(), Guid.NewGuid().ToString()));
                }

                // create
                sw.Restart();
                foreach (var cat in objList)
                {
                    db.Store(cat);
                }

                db.Commit();
                sw.Stop();
                Console.WriteLine($"Time to insert {Math.Pow(10, recordCount)} records: {sw.ElapsedMilliseconds} ms");

                // read
                sw.Restart();
                IObjectSet result = db.QueryByExample(new Category());

                while (result.HasNext())
                {
                    var next = (Category)result.Next();
                }

                sw.Stop();
                Console.WriteLine($"Time to read {Math.Pow(10, recordCount)} records: {sw.ElapsedMilliseconds} ms");

                // delete
                sw.Restart();
                foreach (var cat in objList)
                {
                    db.Delete(cat);
                }

                db.Commit();
                sw.Stop();
                Console.WriteLine($"Time to delete {Math.Pow(10, recordCount)} records: {sw.ElapsedMilliseconds} ms");

                objList.Clear();
            }

            db.Close();
        }
    }

    public override void TestOperation()
    {
        throw new NotImplementedException();
    }

    protected override void CreateIndex()
    {
        Db4oFactory.Configure().ObjectClass(typeof(Category)).ObjectField("Name").Indexed(true);
    }

    protected override void DropIndexes()
    {
        Db4oFactory.Configure().ObjectClass(typeof(Category)).ObjectField("Name").Indexed(false);
    }
}
