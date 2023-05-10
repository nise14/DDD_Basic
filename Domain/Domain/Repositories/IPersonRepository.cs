using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Repositories;

public interface IPersonRepository
{
    Task<Person> GetPersonById(PersonId id);
    Task AddPerson(Person person);
}