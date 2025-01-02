using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spr.ObjectDB.Models;
internal class Ingredient
{
    public Ingredient()
    {
    }

    public Ingredient(int id, string name, string desc)
    {
        this.Id = id;
        this.Name = name;
        this.Description = desc;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public override string ToString()
    {
        return $"{this.Id} {this.Name} {this.Description}";
    }
}
