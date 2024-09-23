using Microsoft.EntityFrameworkCore;
using UserApp.Infrastructure;

namespace UserApp.Api.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static async void ApplyMigration(this IApplicationBuilder applicationBuilder)
        {
            using (var scope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var service = scope.ServiceProvider;
                var loggerFactory = service.GetRequiredService<ILoggerFactory>();

                try
                {
                    var context = service.GetRequiredService<ApplicationDbContext>();
                    await context.Database.MigrateAsync();

                }
                catch (Exception e)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(e, "Error en migracion");
                }
            }
        }
    }
}
