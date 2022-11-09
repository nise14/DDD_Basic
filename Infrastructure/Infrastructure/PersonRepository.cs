using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Infrastructure;

public class PersonRepository : IPersonRepository
{
    private DatabaseContext _db;

    public PersonRepository(DatabaseContext db)
    {
        _db = db;
    }

    public async Task AddPerson(Person person)
    {
        await _db.AddAsync(person);
        await _db.SaveChangesAsync();
    }

    public async Task<Person> GetPersonById(PersonId id)
    {
        return await _db.Persons.FindAsync((Guid)id);
    }
}