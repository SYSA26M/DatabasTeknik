using System;

namespace Client.Models;

public record SalesOrder
{
    public required int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public required string OrderNumber { get; set; }
    public required Customer Customer { get; set; }
    public decimal OrderValue { get; set; }
}
