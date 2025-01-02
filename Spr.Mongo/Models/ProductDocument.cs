using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spr.Mongo.Models;
public class ProductDocument : BaseDocument
{
    public string Name { get; set; }
    public string Description { get; set; }
    public float Power { get; set; }
    public List<ProductRecepie> Recepie { get; set; }
    public MongoDBRef Category { get; set; }
    public string XXX { get; set; }
}
