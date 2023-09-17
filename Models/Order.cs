namespace barraca.Models;

using System.Text.Json.Serialization;
using barraca.Types;

public class Order {
    [JsonIgnore]
    public long Id { get; set; }
    [JsonIgnore]
    public long CustomerId { get; set; }
    public PaymentState Payment { get; set; }
    public Guid Uuid { get; private set; }

    public Order(long customerId, PaymentState payment) {
        CustomerId = customerId;
        Payment = payment;
        Uuid = Guid.NewGuid();
    }
}
