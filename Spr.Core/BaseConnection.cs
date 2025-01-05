using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spr.Core;
public abstract class BaseConnection<Client>
    where Client : class
{
    public BaseConnection(string name)
    {
        _name = name;
    }

    protected string _name;
    protected Client _client;
    public abstract void TestOperation();
    public virtual void TestOperations()
    {
        var sampleCount = new[] { 1, 100, 2000, 4000, 8000, 20000 };

        var sw = new Stopwatch();
        foreach (var samples in sampleCount)
        {
            var ctx = new TestingContext() { DBName = _name, SampleCount = samples };
            var data = CreateSamples(samples);

            try
            {
                foreach (var i in Enumerable.Range(0, 10))
                {
                    sw.Restart();
                    TestInsert(data);
                    sw.Stop();
                    ctx.InsertDurations.Add(sw.ElapsedMilliseconds);

                    sw.Restart();
                    TestUpdate(data);
                    sw.Stop();
                    ctx.UpdateDurations.Add(sw.ElapsedMilliseconds);

                    sw.Restart();
                    TestDelete(data);
                    sw.Stop();
                    ctx.DeleteDurations.Add(sw.ElapsedMilliseconds);
                }
                Console.WriteLine(ctx.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception during testing {this._name}. {ex.Message}");
            }
        }
    }
    protected abstract IEnumerable<object> CreateSamples(int count);
    protected abstract void TestInsert(IEnumerable<object> samples);
    protected abstract void TestUpdate(IEnumerable<object> samples);
    protected abstract void TestDelete(IEnumerable<object> samples);
}
