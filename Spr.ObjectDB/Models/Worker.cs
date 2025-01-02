using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spr.ObjectDB.Models;
internal class Worker
{
    public int Id { get; set; }
    public Identity Identity { get; set; }
    public Contact Contact { get; set; }
    public Position Position { get; set; }

}
