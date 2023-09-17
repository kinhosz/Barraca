using System.Text.Json.Serialization;

namespace barraca.Models;

public class Product {
    [JsonIgnore]
    public long Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public double Value { get; set; }
    public Guid Uuid { get; private set; }

    public Product(string title, double value, string? description) {
        Title = title;
        Description = description;
        Value = value;
        Uuid = Guid.NewGuid();
    }
}
