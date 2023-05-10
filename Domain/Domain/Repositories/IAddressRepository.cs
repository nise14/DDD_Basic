using Domain.Entities;

namespace Domain.Repositories;

public interface IAddressRepository
{
    Task AddAddress(Address toSave);
}