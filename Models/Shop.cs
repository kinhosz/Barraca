using System.Text.Json.Serialization;

namespace barraca.Models;

public class Shop {

    [JsonIgnore]
    public long Id { get; set; }
    [JsonIgnore]
    public long ProductId { get; set; }
    public int Quantity { get; set; }
    [JsonIgnore]
    public long OrderId { get; set; }

    public Shop(long productId, int quantity, long orderId) {
        ProductId = productId;
        Quantity = quantity;
        OrderId = orderId;
    }
}
