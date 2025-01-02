using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spr.ObjectDB.Models;
internal class Product
{
    public int Id { get; set; }
    public int Name { get; set; }
    public int Description { get; set; }
    public int Power { get; set; }
    public int Price { get; set; }
    public int Category { get; set; }
    public Dictionary<Ingredient, int> Recepie { get; set; }
}
