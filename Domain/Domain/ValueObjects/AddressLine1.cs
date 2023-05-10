namespace Domain.ValueObjects;

public record AddressLine1
{
    public AddressLine1() { }

    public string Value { get; init; } = null!;

    internal AddressLine1(string value)
    {
        this.Value = value;
    }

    public static AddressLine1 Create(string value)
    {
        Validate(value);
        return new AddressLine1(value);
    }

    public static void Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentNullException("el valor no debe ser nulo");
        }
    }

}