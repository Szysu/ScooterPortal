using Microsoft.EntityFrameworkCore;

namespace Microsoft.AspNetCore.Builder;

public static class WebApplicationExtensions
{
    public static WebApplication MigrateDbContext<TDbContext>(this WebApplication app) where TDbContext : DbContext
    {
        using var scope = app.Services.CreateScope();
        scope.ServiceProvider.GetRequiredService<TDbContext>().Database.Migrate();
        return app;
    }
}