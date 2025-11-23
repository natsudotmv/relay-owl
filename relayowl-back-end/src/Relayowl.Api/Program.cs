using Microsoft.EntityFrameworkCore;
using Relayowl.Core.Entities;
using Relayowl.Core.Interfaces;
using Relayowl.Core.Respositories;
using Relayowl.Core.Services;
using Relayowl.Infrastructure.Data;
using Relayowl.Infrastructure.Data.Seed.Development;
using Relayowl.Infrastructure.Data.Seed.Production;
using Relayowl.Infrastructure.Repositories;
using Relayowl.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    
    DataSeeder.Seed(context);

    if (app.Environment.IsDevelopment())
    {
        DevDataSeeder.Seed((context));
    }
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
