using MongoDB.Driver;

namespace Spr.Mongo.Models;

public class WarehouseIngredientElement
{
    public int Quantity { get; set; }
    public MongoDBRef Ingredient { get; set; }
}