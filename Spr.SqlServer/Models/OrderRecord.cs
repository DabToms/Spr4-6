using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spr.SqlServer.Models;
internal class OrderRecord
{
    public int Id { get; set; }
    public float TotalPrice { get; set; }
    public string Address { get; set; }
    public int ClientId { get; set; }
}
