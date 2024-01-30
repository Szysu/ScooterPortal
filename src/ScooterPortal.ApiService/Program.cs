using ScooterPortal.ApiService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();
builder.AddSqlServerDbContext<DatabaseContext>("ScooterPortal",
    configureDbContextOptions: optionsBuilder =>
    {
        optionsBuilder.EnableDetailedErrors();
        optionsBuilder.EnableSensitiveDataLogging();
    });

// Add services to the container.
builder.Services.AddFastEndpoints();
builder.Services.AddSingleton<JwtGenerator>();

var app = builder.Build();

// Configure services.
app.UseFastEndpoints();

app.MigrateDatabase();

app.Run();