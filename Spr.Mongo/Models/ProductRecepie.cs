using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spr.Mongo.Models;
public class ProductRecepie
{
    public int Quantity { get; set; }
    public MongoDBRef Ingredient { get; set; }
}
