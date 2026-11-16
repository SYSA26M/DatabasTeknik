using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Client.Models;

public record Customer
{
    public ObjectId Id { get; set; }
    [BsonElement("firstName")]
    public required string FirstName { get; set; }
    [BsonElement("lastName")]
    public required string LastName { get; set; }
    [BsonElement("email")]
    public required string Email { get; set; }
    [BsonElement("phone")]
    public string? Phone { get; set; }
    [BsonElement("address")]
    public Address? Address { get; set; }
}
