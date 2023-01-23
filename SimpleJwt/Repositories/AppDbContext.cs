using Microsoft.EntityFrameworkCore;
using SimpleJwt.Entities;

namespace TokonyadiaRestAPI.Repositories;

public class AppDbContext : DbContext
{
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<UserCredential> UserCredentials => Set<UserCredential>();

    protected AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
}