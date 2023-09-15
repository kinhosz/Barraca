namespace barraca.Models;

using barraca.Types;

public class Order {
    public long Id { get; set; }
    public long CustomerId { get; set; }
    public PaymentState Payment { get; set; }

    public Order(long customerId, PaymentState payment) {
        CustomerId = customerId;
        Payment = payment;
    }
}
