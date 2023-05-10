using Domain.DomainEvents;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Person
{
    public Guid Id { get; init; }
    public PersonName Name { get; private set; } = null!;
    public List<Address> Addresses { get; set; } = null!;

    public Person(Guid id)
    {
        this.Id = id;
    }

    public void SetName(PersonName name)
    {
        this.Name = name;
    }

    public void PersonRegistered(string addressLine, string postalCode)
    {
        Events.PersonCreated.Publish(new PersonCreated(Id, Name,
        new Guid(),
        new AddressLine1(addressLine),
        new AddressPostalCode(postalCode),
        this));
    }
}