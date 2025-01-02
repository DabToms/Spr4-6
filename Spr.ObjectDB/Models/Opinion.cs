using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spr.ObjectDB.Models;
internal class Opinion
{
    public int Id { get; set; }
    public Client Client { get; set; }
    public Product Product { get; set; }
    public int Rating { get; set; }
    public string OpinionText { get; set; }
}
