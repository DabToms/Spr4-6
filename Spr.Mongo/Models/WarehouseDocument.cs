using MongoDB.Driver.GeoJsonObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spr.Mongo.Models;
public class WarehouseDocument : BaseDocument
{
    public string Name { get; set; }
    public LocationElement Location { get; set; }
    public string Type { get; set; }
    public List<WarehouseEquipmentElement> Equipment { get; set; }
    public List<WarehouseWorkerElement> Workers { get; set; }
    public List<WarehouseIngredientElement> Ingredients { get; set; }
    public List<WarehouseProductElement> Products { get; set; }
}
