using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spr.Mongo.Models;
public class OpinionDocument : BaseDocument
{
    public int Rating { get; set; }
    public string Opinion { get; set; }
    public MongoDBRef Client { get; set; }
    public MongoDBRef Product { get; set; }
}
