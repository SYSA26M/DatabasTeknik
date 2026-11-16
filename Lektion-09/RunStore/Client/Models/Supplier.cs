using System;

namespace Client.Models;

public record Supplier
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public override string ToString()
    {
        return Name;
    }
}
