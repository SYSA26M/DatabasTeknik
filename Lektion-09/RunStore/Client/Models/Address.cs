using MongoDB.Bson.Serialization.Attributes;

namespace Client.Models;

public record Address
{
    [BsonElement("addressLine")]
    public string? AddressLine { get; set; }
    [BsonElement("postalCode")]
    public string? PostalCode { get; set; }
    [BsonElement("city")]
    public string? City { get; set; }
}
