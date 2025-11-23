namespace Relayowl.Infrastructure.Data.Seed.Production;

public static class DataSeeder
{
    public static void Seed(AppDbContext context)
    {
        DepartmentSeed.Seed(context);
        UserSeeder.Seed(context);
        context.SaveChanges();
    }
}