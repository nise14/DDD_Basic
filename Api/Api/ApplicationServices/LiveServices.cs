using Api.Commands;
using Api.Queries;
using Domain.DomainEvents;
using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Api.ApplicationServices;

public class LiveServices
{
    private readonly IPersonRepository _repository;
    private readonly IAddressRepository _addressRepository;
    private readonly PersonQueries _personQueries;

    public LiveServices(IPersonRepository repository, PersonQueries personQueries, IAddressRepository addressRepository)
    {
        _repository = repository;
        _personQueries = personQueries;
        _addressRepository = addressRepository;

        Events.PersonCreated.Register(async (parameter) =>
        {
            var address = new Address(parameter.id);
            address.SetAddressLine1(parameter.AddressLine1);
            address.SetPostalCode(parameter.postalCode);
            address.SetPersonId(parameter.person);

            await _addressRepository.AddAddress(address);
            Console.WriteLine("Se ejecuto el evento de dominio");
        });
    }

    public async Task HandleCommand(CreatePersonCommand createPerson)
    {
        Person person = new Person(PersonId.Create(createPerson.personId));
        person.SetName(PersonName.Create(createPerson.Name));
        await _repository.AddPerson(person);
        person.PersonRegistered(createPerson.addressLine, createPerson.postalCode);
    }

    public async Task<Person> GetPerson(Guid id)
    {
        return await _personQueries.GetPersonByIdAsync(id);
    }
}