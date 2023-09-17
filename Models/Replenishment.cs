using System.Text.Json.Serialization;

namespace barraca.Models;

public class Replenishment {
    [JsonIgnore]
    public long Id { get; set; }
    [JsonIgnore]
    public long ProductId { get; set; }
    public int Quantity { get; set; }
    public Guid Uuid { get; private set; }

    public Replenishment(long productId, int quantity) {
        ProductId = productId;
        Quantity = quantity;
        Uuid = Guid.NewGuid();
    }
}
