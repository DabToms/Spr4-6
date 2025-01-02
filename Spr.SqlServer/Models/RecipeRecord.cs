using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spr.ObjectDB.Models;
internal class RecipeRecord
{
    public int Id { get; set; }
    public int ProdictId { get; set; }
    public int IngredientId { get; set; }
    public int Quantity { get; set; }
}
