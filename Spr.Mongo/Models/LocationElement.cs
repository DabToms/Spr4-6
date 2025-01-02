using MongoDB.Driver.GeoJsonObjectModel;

namespace Spr.Mongo.Models;

public class LocationElement
{
    public string Type { get; set; }
    public GeoJsonCoordinates Coordinates { get; set; }
    public AddressElement Address { get; set; }
}