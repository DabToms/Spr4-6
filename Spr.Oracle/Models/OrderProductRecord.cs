using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spr.Oracle.Models;
internal class OrderProductRecord
{
    public int Id { get; set; }
    public int TotalPrice { get; set; }
    public int ProductId { get; set; }
    public int OrderId { get; set; }
    public int Quantity { get; set; }
}
