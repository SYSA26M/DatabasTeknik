namespace Client.Models;

public record Customer
{
    public string Id { get; set; } = string.Empty;
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public string? Phone { get; set; }
    public Address? Address { get; set; }
}
