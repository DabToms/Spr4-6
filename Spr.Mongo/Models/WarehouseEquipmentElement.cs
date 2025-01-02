using MongoDB.Bson.Serialization.Attributes;

namespace Spr.Mongo.Models;

public class WarehouseEquipmentElement
{
    public string Name { get; set; }

    [BsonElement("serial_number")]
    public string SerialNumber { get; set; }
    public string State { get; set; }
}