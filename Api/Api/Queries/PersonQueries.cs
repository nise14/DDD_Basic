using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Api.Queries;

public class PersonQueries
{
    private readonly IPersonRepository _personRepository;

    public PersonQueries(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<Person> GetPersonByIdAsync(Guid id)
    {
        var response = await _personRepository.GetPersonById(PersonId.Create(id));
        return response;
    }
}