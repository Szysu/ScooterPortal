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
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

app.MapDefaultEndpoints();

// Migrate the database.
app.MigrateDbContext<DatabaseContext>();

app.Run();