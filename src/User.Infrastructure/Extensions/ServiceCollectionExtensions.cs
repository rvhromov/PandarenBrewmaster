using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using User.Infrastructure.Persistence;
using User.Infrastructure.Repositories;

namespace User.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAppDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options
                    .UseLazyLoadingProxies()
                    .UseSqlServer(connectionString, builder => builder.MigrationsAssembly("User.Infrastructure"));
            });
            
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}