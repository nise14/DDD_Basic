namespace Domain.ValueObjects;

public record PersonId
{
    public Guid Value { get; init; }

    internal PersonId(Guid value)
    {
        this.Value = value;
    }

    public static PersonId Create(Guid value)
    {
        return new PersonId(value);
    }

    public static implicit operator Guid(PersonId personId)
    {
        return personId.Value;
    }
}