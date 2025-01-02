using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spr.Mongo.Models;
public class ContactElement
{
    public string Email { get; set; }

    [BsonElement("phone_number")]
    public string PhoneNumber { get; set; }
}
