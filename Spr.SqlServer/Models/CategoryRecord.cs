using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spr.SqlServer.Models;

[Table("Category")]
[PrimaryKey(nameof(Id))]
public class CategoryRecord
{
    public CategoryRecord()
    {
    }

    public CategoryRecord(int id, string name, string desc)
    {
        this.Id = id;
        this.Name = name;
        this.Description = desc;
    }
    

    public CategoryRecord( string name, string desc)
    {
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
