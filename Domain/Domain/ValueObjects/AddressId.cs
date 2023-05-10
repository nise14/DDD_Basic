namespace Domain.ValueObjects;

public record AddressId
{
    public AddressId() { }

    public Guid Value { get; init; }

    internal AddressId(Guid value)
    {
        this.Value = value;
    }

    public static AddressId create(Guid value)
    {
        return new AddressId(value);
    }

    public static implicit operator Guid(AddressId personId)
    {
        return personId.Value;
    }
}