using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spr.Oracle.Models;
internal class ClientRecord
{
    public int Id { get; set; }
    public Identity Identity { get; set; }
    public Contact Contact { get; set; }
    public Location Location { get; set; }
    public int TotalOrderNumber { get; set; }
}
