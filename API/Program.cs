var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddContext<DataContext>(opt =>
{
    opt.UserSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

app.MapControllers();

app.Run();
