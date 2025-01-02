using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spr.Oracle.Models;
internal class WarehouseRecord
{
    public int Id { get; set; }
    public int Name { get; set; }
    public Location Location { get; set; }
    public string Type { get; set; }
}
