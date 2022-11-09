using Api.Commands;
using Api.Queries;
using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Api.ApplicationServices;

public class LiveServices
{
    private readonly IPersonRepository _repository;
    private readonly PersonQueries _personQueries;

    public LiveServices(IPersonRepository repository, PersonQueries personQueries)
    {
        _repository = repository;
        _personQueries = personQueries;
    }

    public async Task HandleCommand(CreatePersonCommand createPerson)
    {
        Person person = new Person(PersonId.Create(createPerson.personId));
        person.SetName(PersonName.Create(createPerson.Name));
        await _repository.AddPerson(person);
    }

    public async Task<Person> GetPerson(Guid id)
    {
        return await _personQueries.GetPersonByIdAsync(id);
    }
}