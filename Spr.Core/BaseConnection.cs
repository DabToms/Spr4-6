using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spr.Core;
public abstract class BaseConnection<Client>
    where Client : class
{
    protected Client _client;
    public abstract void Connect();
}
