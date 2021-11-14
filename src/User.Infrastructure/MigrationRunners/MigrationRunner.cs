using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using User.Infrastructure.Persistence;

namespace User.Infrastructure.MigrationRunners
{
    public static class MigrationRunner
    {
        public static void ApplyMigrations(IServiceProvider serviceProvider)
        {
            if (serviceProvider is null)
                throw new ArgumentNullException(nameof(serviceProvider));

            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<AppDbContext>();
            
            Console.WriteLine("Applying migrations...");

            try
            {
                dbContext?.Database.Migrate();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to apply migrations. {e.Message}");
            }
        } 
    }
}