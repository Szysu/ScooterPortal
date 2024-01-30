var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults()
    .AddSqlServerDbContext<DatabaseContext>("ScooterPortal",
        configureDbContextOptions: optionsBuilder =>
        {
            optionsBuilder.EnableDetailedErrors();
            optionsBuilder.EnableSensitiveDataLogging();
        });

// Add services to the container.
builder.Services
    .AddFastEndpoints()
    .AddJWTBearerAuth(builder.Configuration["JwtKey"]!)
    .AddAuthorization();

var app = builder.Build();

app.UseAuthentication()
    .UseAuthorization()
    .UseFastEndpoints()
    .MigrateDatabase();

app.Run();