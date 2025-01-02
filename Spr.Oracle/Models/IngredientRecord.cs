using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spr.Oracle.Models;
internal class IngredientRecord
{
    public IngredientRecord()
    {
    }

    public IngredientRecord(int id, string name, string desc)
    {
        this.Id = id;
        this.Name = name;
        this.Description = desc;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    public int? ProductId { get; set; }
    public int? WarehouseId { get; set; }
    public override string ToString()
    {
        return $"{this.Id} {this.Name} {this.Description}";
    }
}
