using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spr.Mongo.Models;
public class OrderDocument : BaseDocument
{
    [BsonElement("total_price")]
    public float TotalPrice { get; set; }
    public AddressElement Address { get; set; }
    public List<OrderProductElement> Products { get; set; }
}
