using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spr.ObjectDB.Models;
internal class ProductStock
{
    public int Id { get; set; }
    public Product Product { get; set; }
    public string ProductionNumber { get; set; }
    public DateTime ProductionDate { get; set; }
    public int ProductionQuantity { get; set; }
    public int QuantityLeft { get; set; }
}
