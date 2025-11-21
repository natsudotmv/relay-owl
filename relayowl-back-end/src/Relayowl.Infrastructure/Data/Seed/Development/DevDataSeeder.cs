using Relayowl.Core.Entities;

namespace Relayowl.Infrastructure.Data.Seed.Development;

public static class DevDataSeeder
{
    public static void Seed(AppDbContext context)
    {
        LocationSeeder.Seed(context);

        context.SaveChanges();
    }
}