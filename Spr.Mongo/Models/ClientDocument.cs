using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spr.Mongo.Models;
public class ClientDocument : BaseDocument
{
    public string Name { get; set; }
    public ContactElement Contact { get; set; }
    public AddressElement Address { get; set; }
    public DateTime RegistrationDate { get; set; }
}
