using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Relayowl.Core.Entities;
using Relayowl.Infrastructure.Identity;

namespace Relayowl.Infrastructure.Data;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<DomainUser> DomainUsers { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Comment> Comments { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        List<IdentityRole> roles = new List<IdentityRole>
        {
            new IdentityRole
            {
                Id = "1",
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Id = "3",
                Name = "Staff",
                NormalizedName = "STAFF"
            }
        };
        
        builder.Entity<IdentityRole>().HasData(roles);
        
        builder.Entity<DomainUser>().ToTable("DomainUser");
        builder.Entity<Department>().ToTable("Department");
        builder.Entity<Location>().ToTable("Location");
        builder.Entity<Ticket>().ToTable("Ticket");
        builder.Entity<DomainUser>().ToTable("DomainUser");
        builder.Entity<Comment>().ToTable("Comment");
    }
}