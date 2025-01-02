using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spr.Mongo.Models;
public class IngredientDocument : BaseDocument
{
    public string Name { get; set; }
    public string Description { get; set; }
}
