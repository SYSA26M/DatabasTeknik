using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Client.Models;

public record Supplier
{
    [BsonIgnoreIfDefault]
    public ObjectId Id { get; set; }
    [BsonElement("supplierName")]
    public string Name { get; set; } = string.Empty;
    public override string ToString()
    {
        return Name;
    }
}
