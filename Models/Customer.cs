namespace barraca.Models;

public class Customer {
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public Customer(string email, string name) {
        Name = name;
        Email = email;
    }
}
