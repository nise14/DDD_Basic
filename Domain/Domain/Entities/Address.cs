using Domain.ValueObjects;

namespace Domain.Entities;

public class Address
{
    public Guid Id { get; init; }

    public AddressLine1? AddressLine1 { get; private set; }
    public AddressPostalCode? AddressPostalCode { get; set; }
    public Guid? PersonId { get; set; }
    public Person? Person { get; set; }

    public Address(Guid id)
    {
        this.Id = id;
    }

    public void SetAddressLine1(AddressLine1 name)
    {
        AddressLine1 = name;
    }

    public void SetPostalCode(AddressPostalCode name)
    {
        AddressPostalCode = name;
    }

    public void SetPersonId(Person name)
    {
        PersonId = name.Id;
    }
}