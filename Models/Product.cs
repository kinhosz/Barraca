namespace barraca.Models;

public class Product {
    public long Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public double Value { get; set; }

    public Product(string title, double value, string? description) {
        Title = title;
        Description = description;
        Value = value;
    }
}
