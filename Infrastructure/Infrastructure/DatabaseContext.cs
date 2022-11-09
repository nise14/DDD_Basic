using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;
public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public DbSet<Person> Persons { get; set; }

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

        base.OnModelCreating(modelBuilder);
    }
}
