using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Spr.Oracle.Models;
internal class WorkeRecord
{
    public int Id { get; set; }
    public Identity Identity { get; set; }
    public Location Location { get; set; }
    public Position Position { get; set; }
    public Contact Contact { get; set; }
    public int WarehouseId { get; set; }
}
