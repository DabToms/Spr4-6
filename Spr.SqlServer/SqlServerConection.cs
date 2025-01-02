using Spr.Core;

namespace Spr.SqlServer;

public class SqlServerConection : BaseConnection<TestContext>
{
    public override void Connect()
    {
        this._client = new TestContext();
    }

}
