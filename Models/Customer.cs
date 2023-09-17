using System.Text.Json.Serialization;

namespace barraca.Models;

public class Customer {
    [JsonIgnore]
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public Guid Uuid { get; private set; }

    public Customer(string name, string email) {
        Name = name;
        Email = email;
        Uuid = Guid.NewGuid();
    }
}
