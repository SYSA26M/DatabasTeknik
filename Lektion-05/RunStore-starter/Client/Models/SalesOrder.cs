using System;

namespace Client.Models;

public record SalesOrder
{
    public required string Id { get; set; }
    public DateTime OrderDate { get; set; }
}
