using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure;

public class AddressRepository : IAddressRepository
{
    private readonly DatabaseContext _context;

    public AddressRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task AddAddress(Address toSave)
    {
        await _context.AddAsync(toSave);
        _context.SaveChanges();
    }
}