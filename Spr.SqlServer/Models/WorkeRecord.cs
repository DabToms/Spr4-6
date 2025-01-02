using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Spr.SqlServer.Models;
internal class WorkeRecord
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Phonenumber { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public float Salary { get; set; }
    public int WarehouseId { get; set; }

}
