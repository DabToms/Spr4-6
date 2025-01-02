using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spr.Oracle.Models;
internal class Location
{
    public string City { get; set; }
    public string Street { get; set; }
    public string StreetNumber { get; set; }
    public float Latitude { get; set; }
    public float Longitude { get; set; }
}
