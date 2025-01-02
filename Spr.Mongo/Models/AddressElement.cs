using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spr.Mongo.Models;
public class AddressElement
{
    public string City { get; set; }
    public string Street { get; set; }
    [BsonElement("street_number")]
    public string StreetNumber { get; set; }
}
