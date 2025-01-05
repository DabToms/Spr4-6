using Db4objects.Db4o;
using Spr.ObjectDB.Models;
using System;
using System.Diagnostics;

namespace Spr.ObjectDB;

public class ObjectDBConnection
{
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
}
