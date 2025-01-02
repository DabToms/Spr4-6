using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spr.SqlServer.Models;
internal class EquipmentRecord
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string SerialNumber { get; set; }
    public string State { get; set; }
    public int WarehouseId { get; set; }
}
