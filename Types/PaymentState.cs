using System.Runtime.Serialization;

namespace barraca.Types;

public enum PaymentState {
    [EnumMember(Value = "Draft")]
    Draft,
    [EnumMember(Value = "Paid")]
    Paid,
    [EnumMember(Value = "Pending")]
    Pending
}