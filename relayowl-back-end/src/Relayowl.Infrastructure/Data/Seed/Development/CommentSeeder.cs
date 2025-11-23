namespace Relayowl.Infrastructure.Data.Seed.Development;

public static class CommentSeeder
{
    public static void Seed(AppDbContext context)
    {
        if (!context.Comments.Any())
        {
            return; // DB has been seeded
        }

        var comments = new List<Core.Entities.Comment>
        {
            new Core.Entities.Comment
            {
                Id = 1,
                Message = "This is the first comment.",
                TicketId = 5,
                UserId = 1,
                CreatedAt = DateTime.UtcNow.AddDays(-5)
            },
            new Core.Entities.Comment
            {
                Id = 2,
                Message = "This is the second comment.",
                TicketId = 6,
                UserId = 1,
                CreatedAt = DateTime.UtcNow.AddDays(-4)
            },
            new Core.Entities.Comment
            {
                Id = 3,
                Message = "This is the third comment.",
                TicketId = 7,
                UserId = 1,
                CreatedAt = DateTime.UtcNow.AddDays(-3)
            }
        };

        context.Comments.AddRange(comments);
        context.SaveChanges();
    }
}