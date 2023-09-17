namespace barraca.Models;

public class Stock {
    public Product ProductAvailable { get; set; }
    public int Quantity { get; set; }

    public Stock(Product product, int quantity) {
        ProductAvailable = product;
        Quantity = quantity;
    }
}
