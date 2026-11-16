using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Client.Models;

public record Product
{
    [BsonIgnoreIfDefault]
    public ObjectId Id { get; set; }
    [BsonElement("description")]
    public string? Description { get; set; }
    [BsonElement("imageUrl")]
    public string? ImageUrl { get; set; }
    [BsonElement("itemNumber")]
    public required string ItemNumber { get; set; }
    [BsonElement("name")]
    public required string Name { get; set; }
    [BsonElement("price")]
    public int Price { get; set; }
    [BsonElement("supplier")]
    public required Supplier Supplier { get; set; }
}
