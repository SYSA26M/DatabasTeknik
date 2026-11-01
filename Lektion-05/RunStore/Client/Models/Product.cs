using System;

namespace Client.Models;

public record Product
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public required string ItemNumber { get; set; }
    public required string Name { get; set; }
    public int Price { get; set; }
    public string? SupplierName { get; set; }
}
