namespace barraca.Models;

public class Shop {
    public long Id { get; set; }
    public long ProductId { get; set; }
    public int Quantity { get; set; }
    public long OrderId { get; set; }

    public Shop(long productId, int quantity, long orderId) {
        ProductId = productId;
        Quantity = quantity;
        OrderId = orderId;
    }
}
