namespace Relayowl.Infrastructure.Data.Seed.Development;

public static class CommentSeeder
{
    public static void Seed(AppDbContext context)
    {
        if (!context.Comments.Any())
        {
            context.Comments.AddRange(
                new Core.Entities.Comment
                {
                    Id = 1,
                    Message = "This is the first comment.",
                    TicketId = 1,
                    UserId = 1,
                    CreatedAt = DateTime.UtcNow.AddDays(-5)
                },
                new Core.Entities.Comment
                {
                    Id = 2,
                    Message = "This is the second comment.",
                    TicketId = 2,
                    UserId = 1,
                    CreatedAt = DateTime.UtcNow.AddDays(-4)
                },
                new Core.Entities.Comment
                {
                    Id = 3,
                    Message = "This is the third comment.",
                    TicketId = 2,
                    UserId = 1,
                    CreatedAt = DateTime.UtcNow.AddDays(-3)
                }
            );
        }
        context.SaveChanges();
    }
}