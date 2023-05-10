using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;
public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public DbSet<Person> Persons { get; set; } = null!;
    public DbSet<Address> Address { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>(o =>
        {
            o.HasKey(x => x.Id);
        });

        modelBuilder.Entity<Person>().OwnsOne(o => o.Name, conf =>
        {
            conf.Property(x => x.Value).HasColumnName("Name");
        });

        modelBuilder.Entity<Address>().OwnsOne(o => o.AddressLine1, conf =>
        {
            conf.Property(x => x.Value).HasColumnName("Line1");
        });

        modelBuilder.Entity<Address>().OwnsOne(o => o.AddressPostalCode, conf =>
        {
            conf.Property(x => x.Value).HasColumnName("PostalCode");
        });

        modelBuilder.Entity<Person>().HasMany(o => o.Addresses)
            .WithOne(o => o.Person)
            .HasForeignKey(o => o.PersonId);

        base.OnModelCreating(modelBuilder);
    }
}
