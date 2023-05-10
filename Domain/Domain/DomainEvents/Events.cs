namespace Domain.DomainEvents;

public static class Events
{
    public static readonly DomainEvent<PersonCreated> PersonCreated = new DomainEvent<PersonCreated>();
}