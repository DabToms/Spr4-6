namespace Spr.Mongo.Models;

public class WarehouseWorkerElement
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public ContactElement Contact { get; set; }
    public float Salary { get; set; }
    public DateTime HireDate { get; set; }
    public string State { get; set; }
}