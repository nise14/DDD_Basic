using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.DomainEvents;

public record PersonCreated(Guid id, PersonName? name, Guid idAddress, AddressLine1 AddressLine1, AddressPostalCode postalCode, Person person);