namespace Client.Models;

public record Product
{
    public string Id { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public required string ItemNumber { get; set; }
    public required string Name { get; set; }
    public int Price { get; set; }
    public required Supplier Supplier { get; set; }
}
