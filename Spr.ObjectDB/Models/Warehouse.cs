using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spr.ObjectDB.Models;
internal class Warehouse
{
    public int Id { get; set; }
    public int Name { get; set; }
    public Dictionary<Ingredient, int> Ingredients { get; set; }
    public List<Equipment> Equipment { get; set; }
    public Location Location { get; set; }
    public List<Worker> Workers { get; set; }
    public List<ProductStock> Products { get; set; }
}
