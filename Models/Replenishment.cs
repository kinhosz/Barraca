namespace barraca.Models;

public class Replenishment {
    public long Id { get; set; }
    public long ProductId { get; set; }
    public int Quantity { get; set; }

    public Replenishment(long productId, int quantity) {
        ProductId = productId;
        Quantity = quantity;
    }
}
