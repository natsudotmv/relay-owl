using Microsoft.EntityFrameworkCore;
using Relayowl.Core.Entities;

namespace Relayowl.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Department> Messages { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<User> User { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>().ToTable("User");
        builder.Entity<Department>().ToTable("Department");
        builder.Entity<Location>().ToTable("Location");
        builder.Entity<Ticket>().ToTable("Ticket");
        builder.Entity<User>().ToTable("User");
    }
}