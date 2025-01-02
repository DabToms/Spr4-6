using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace Spr.Mongo.Models;

public class WarehouseProductElement
{
    [BsonElement("production_number")]
    public string ProductionNumber { get; set; }

    [BsonElement("production_date")]
    public DateTime ProductionDate { get; set; }

    [BsonElement("production_quantity")]
    public int ProductionQuantity { get; set; }

    [BsonElement("quantity_left")]
    public int QuantityLeft { get; set; }
    public MongoDBRef Product { get; set; }
}