namespace Domain.ValueObjects;

public record AddressPostalCode
{
    public AddressPostalCode()
    {
    }

    public string Value { get; init; } = null!;

    internal AddressPostalCode(string value)
    {
        Value = value;
    }

    public static AddressPostalCode Create(string value)
    {
        Validate(value);
        return new AddressPostalCode(value);
    }

    public static void Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentNullException("valor no puede ser null");
        }
    }
}