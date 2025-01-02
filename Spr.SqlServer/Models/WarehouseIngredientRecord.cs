using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spr.SqlServer.Models;
internal class WarehouseIngredientRecord
{
    public WarehouseIngredientRecord()
    {
    }

    public WarehouseIngredientRecord(int id, string name, string desc)
    {
        this.Id = id;
    }
    public int Id { get; set; }
    public int WarehouseId { get; set; }
    public int IngredientId { get; set; }
    public DateTime BuyDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    public int Quantity { get; set; }
}
