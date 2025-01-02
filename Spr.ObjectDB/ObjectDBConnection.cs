using Db4objects.Db4o;
using Spr.ObjectDB.Models;
using System;

namespace Spr.ObjectDB;

public class ObjectDBConnection
{
    public void Test()
    {
        //open database file "person.data"
        using (IObjectContainer db = Db4oEmbedded.OpenFile("person.data"))
        {
            //declare some persons
            Category stefan = new Category(1, "Max", "Mustermann");
            Category pohl = new Category(2, "Alfred", "Adams");
            Category eckl = new Category(3, "Florian", "Dietrich");
            //store the persons in the database
            db.Store(stefan);
            db.Store(pohl);
            db.Store(eckl);
            db.Commit();
            //

            //fetch all Persons from the database
            IObjectSet result = db.QueryByExample(new Category());

            //query through the results and print them out
            while (result.HasNext())
            {
                Category next = (Category)result.Next();
                Console.WriteLine(next.ToString());
            }

            Console.Read();

            //Close the database
            db.Close();
        }
    }
}
