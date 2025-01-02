using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spr.ObjectDB.Models;
internal class Order
{
    public int Id { get; set; }
    public int TotalPrice { get; set; }
    public int Location { get; set; }
    public Client Client { get; set; }
    public Product Products { get; set; }
}
